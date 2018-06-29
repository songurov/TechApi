using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.WebPages;
using TechApi.Data;
using TechApi.Extensions;
using TechApi.Models;

namespace TechApi.Controllers
{
    public class YellowPageController : ApiController
    {
        private const string StringSelect = "NOME," +
                                            "COGNOME," +
                                            "POSIZIONE," +
                                            "SOCIETA," +
                                            "SOLUTION," +
                                            "MAIL_UTENTE as mail," +
                                            "CITTA," +
                                            "DIPARTIMENTO";

        private const string TableQuery = "IM_ELENCO_PERSONALE";

        private const string StringSelectContact = @"
                                                    NOME
                                                    ,COGNOME
                                                    ,POSIZIONE
                                                    ,SOCIETA
                                                    ,SOLUTION
                                                    ,MAIL_UTENTE as mail
                                                    ,CITTA
                                                    ,DIPARTIMENTO
                                                    ,INDIRIZZO
                                                    ,CAP
                                                    ,STANZA
                                                    ,TELEFONO
                                                    ,NUMERO_CELL as mobile
                                                    ,CELL_PUBBLICO as mobilepubblico
                                                    ,FAX
                                                    ,INTERNO
                                                    ,INTERNOSEGRETARIA as segretaria
                                                    ,EXTENSIONATTRIBUTE1 as attributo1";

        private const string Name = "nome";
        private const string LastName = "cognome";

        private const string Mail = "mail";

        private const string Solution = "solution";
        private const string Position = "posizione";
        private const string Society = "societa";

        private readonly SqlWrapper _DATA_BASE;

        public YellowPageController()
        {
            _DATA_BASE = new SqlWrapper();
        }

        [Route("KPMGYP/yellowpage/ricerca")]
        [HttpGet]
        public IHttpActionResult Ricerca()
        {
            var name = GetHttpResult(Name);
            var cognome = GetHttpResult(LastName);
            var solution = GetHttpResult(Solution);
            var posizione = GetHttpResult(Position);
            var societa = GetHttpResult(Society);

            var final = string.Empty;
            IList<ItemSqlParams> @params = new List<ItemSqlParams>();

            const string template = "SELECT " + StringSelect +
                                    " FROM " + TableQuery +
                                    " WHERE {0}";

            if (!name.IsEmpty())
            {
                final = string.Format(template, "NOME LIKE @" + Name + " ");
                @params.Add(new ItemSqlParams { Name = Name, Value = name + "%" });
            }

            final = AddWhere(cognome, LastName, final, @params, template);
            final = AddWhere(solution, Solution, final, @params, template);
            final = AddWhere(posizione, Position, final, @params, template);
            final = AddWhere(societa, Society, final, @params, template);

            if (final.IsEmpty()) return Ok(new List<UserModelSearch>());

            try
            {
                _DATA_BASE.Command(final, @params);
            }
            catch (System.Exception)
            {
                return Ok(new List<UserModelSearch>());
            }

            var model = _DATA_BASE.GetObject<UserModelSearch[]>();

            return Ok(model);
        }

        private static string AddWhere(string societaUrl, string socientaProp, string final, ICollection<ItemSqlParams> @params, string template)
        {
            if (societaUrl.IsEmpty()) return final;
            final += final.IsEmpty() ? string.Format(template, " " + socientaProp.ToUpperInvariant() + " LIKE @" + socientaProp) :
                " AND " + socientaProp.ToUpperInvariant() + " LIKE @" + socientaProp + " ";
            @params.Add(new ItemSqlParams { Name = socientaProp, Value = societaUrl + "%" });

            return final;
        }

        [Route("KPMGYP/yellowpage/getContatto")]
        [HttpGet()]
        public IHttpActionResult GetContatto()
        {
            var name = GetHttpResult(Name);
            var mail = GetHttpResult(Mail);
            var cognome = GetHttpResult(LastName);

            var final = string.Empty;
            IList<ItemSqlParams> @params = new List<ItemSqlParams>();
            @params.Clear();

            const string template = "SELECT " + StringSelectContact +
                                    " FROM " + TableQuery +
                                    " WHERE {0}";

            if (!name.IsEmpty())
            {
                final = string.Format(template, "NOME= @" + Name + " ");
                @params.Add(new ItemSqlParams { Name = Name, Value = name });
            }
            if (!cognome.IsEmpty())
            {
                final += final.IsEmpty() ? string.Format(template, " COGNOME= @" + LastName + " ") :
                    " AND COGNOME= @" + LastName + " ";
                @params.Add(new ItemSqlParams { Name = LastName, Value = cognome });
            }
            if (!mail.IsEmpty())
            {
                final += final.IsEmpty() ? string.Format(template, " MAIL_UTENTE= @" + Mail + " ") :
                    " AND MAIL_UTENTE= @" + Mail + " ";
                @params.Add(new ItemSqlParams { Name = Mail, Value = mail });
            }

            if (final.IsEmpty()) return Ok(new UserModelContact());

            try
            {
                _DATA_BASE.Command(final, @params);
            }
            catch (System.Exception)
            {
                return Ok(new UserModelContact());
            }

            var model = _DATA_BASE.GetObject<UserModelContact[]>();

            if (cognome.IsEmpty() && mail.IsEmpty() && name.IsEmpty()) return Ok(new UserModelContact());
            var a = model.FirstOrDefault(x => x.cognome.Equals(cognome) ||
                                                    x.mail.Equals(mail) ||
                                                    x.nome.Equals(name));

            return Ok(a ?? new UserModelContact());
        }

        private static string GetHttpResult(string nameProp) => HttpContext.Current.Request.QueryString[nameProp]?.Replace("’", "'");
    }
}
