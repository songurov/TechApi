using System.Collections.Generic;
using TechApi.Data;
using TechApi.Models;
using System.Linq;
using Newtonsoft.Json;

namespace TechApi.Extensions
{
    public static class JsonExtensions
    {
        public static T GetObject<T>(this SqlWrapper sqlWrapper)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(sqlWrapper.DATA_TABLE));
        }

        public static UserModelContact[] GetUserModelContactDb(this SqlWrapper sqlWrapper)
        {
            var result = new List<UserModelContact>();
            foreach (System.Data.DataRow row in sqlWrapper.DATA_TABLE.Rows)
            {
                result.Add(new UserModelContact
                {
                    nome = row["NOME"].ToString().Trim(),
                    cognome = row["COGNOME"].ToString().Trim(),
                    posizione = row["POSIZIONE"].ToString().Trim(),
                    societa = row["SOCIETA"].ToString().Trim(),
                    solution = row["SOLUTION"].ToString().Trim(),
                    mail = row["mail"].ToString().Trim(),
                    citta = row["CITTA"].ToString().Trim(),
                    dipartimento = row["DIPARTIMENTO"].ToString().Trim(),
                    indirizzo = row["INDIRIZZO"].ToString().Trim(),
                    cap = row["CAP"].ToString().Trim(),
                    stanza = row["STANZA"].ToString().Trim(),
                    telefono = row["TELEFONO"].ToString().Trim(),
                    mobile = row["NUMERO_CELL"].ToString().Trim(),
                    mobilepubblico = row["mobilepubblico"].ToString().Trim(),
                    fax = row["FAX"].ToString().Trim(),
                    interno = row["INTERNO"].ToString().Trim(),
                    segretaria = row["segretaria"].ToString().Trim(),
                    attributo1 = row["attributo1"].ToString().Trim()
                });
            }
            return result.ToArray();
        }

        public static UserModelSearch[] GetUserModelSearchDb(this SqlWrapper sqlWrapper)
        {
            var result = new List<UserModelSearch>();
            foreach (System.Data.DataRow row in sqlWrapper.DATA_TABLE.Rows)
            {
                result.Add(new UserModelSearch
                {
                    nome = row["NOME"].ToString().Trim(),
                    cognome = row["COGNOME"].ToString().Trim(),
                    posizione = row["POSIZIONE"].ToString(),
                    societa = row["SOCIETA"].ToString().Trim(),
                    solution = row["SOLUTION"].ToString().Trim(),
                    mail = row["mail"].ToString().Trim(),
                    citta = row["CITTA"].ToString().Trim()
                });
            }
            return result.OrderBy(x => x.nome).ThenBy(x => x.cognome).ToArray();
        }
    }
}