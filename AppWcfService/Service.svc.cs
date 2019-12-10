using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppWcfService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service.svc ou Service.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service : IService
    {
        public string DoWork()
        {
            return "Ola Mundo";
        }

        public Weeks[] Listar()
        {
            var culture = new System.Globalization.CultureInfo("pt-BR");
            Weeks[] weeks = new Weeks[7];

            var day = DateTime.Now;
            for(int i = 0; i < 7 ; i++)
            {
                var week = new Weeks
                {
                    active = false,
                    day = culture.DateTimeFormat.GetDayName(day.DayOfWeek),                   
                    date = day.Date.ToString("dd/MM/yyyy")
                };
                day = day.AddDays(1);
                weeks[i] = week;
            }

            return weeks;

        }

        public string Inserir(Usuario usuario)
        {
            return "Inserido com sucesso!" + usuario.Nome;
        }
    }
}
