using System;
using System.Collections.Generic;
using System.Text;

namespace TobisWorldMG
{
    class CommandService
    {
        private static List<Command> commandList = new List<Command>()
        {
            new Command(){name = "probe", func = EvalRole, desc="körper, geist, gefühl, würfelwurf" },
            new Command(){name = "schaden", func = EvalRole },
            new Command(){name = "set", func = Set},
            new Command(){name = "add", func = Add}
        };


        public static void DoCommand(string commandString)
        {
            var commandAttrs = commandString.Split(' ');
            Command command = commandList.Find(c => c.name == commandAttrs[0]);
            if (command != null)
            {
                if (commandAttrs.Length == 1)
                {
                    PrintDescription(command);
                }
                else
                {
                    command.func(commandAttrs);
                }

            }


        }

        private static void PrintDescription(Command command)
        {
            Console.WriteLine(command.desc);
        }

        private static void EvalRole(string[] array)
        {
            int body;
            int mind;
            int feeling;
            int health;
            int mentalHealth;
            int role;
            int.TryParse(array[1], out body);
            int.TryParse(array[2], out mind);
            int.TryParse(array[3], out feeling);
            int.TryParse(array[4], out health);
            int.TryParse(array[5], out mentalHealth);
            int.TryParse(array[6], out role);

            double min =
              ((
                  ((Charakter.instance.Body / 100.0) * body) +
                  ((Charakter.instance.Mind / 100.0) * mind) +
                  ((Charakter.instance.Feeling / 100.0) * feeling)
              ) * 0.8) +
             ((
                ((Charakter.instance.Health / 100.0) * health) +
                 ((Charakter.instance.MentalHealth / 100.0) * mentalHealth)
             ) * 0.2);

            double dif = (min - role);
            string success = (role <= min) ? "Erfolg" : "Misserfolg";

            Console.WriteLine(String.Format($"min: {min} wurf:{role}"));
            Console.WriteLine(success);
            Console.WriteLine(dif);
        }
        private static void Set(string[] array)
        {
            string valueName = array[1];
            int newValue;
            int.TryParse(array[2], out newValue);

            string upper = char.ToUpper(valueName[0]) + valueName.Substring(1);


            var prop = Charakter.instance.GetType().GetProperty(upper);
            if (prop != null)
            {
                prop.SetValue(Charakter.instance, newValue);
                Console.WriteLine(Charakter.instance);
            }
        }

        private static void Add(string[] array)
        {
            string valueName = array[1];
            int newValue;
            int.TryParse(array[2], out newValue);

            string upper = char.ToUpper(valueName[0]) + valueName.Substring(1);
            
            var prop = Charakter.instance.GetType().GetProperty(upper);

            if (prop != null && (prop.PropertyType == typeof(int)))
            {
                int i = (Convert.ToInt32(prop.GetValue(Charakter.instance)));

                prop.SetValue(Charakter.instance, i + newValue);
                Console.WriteLine(Charakter.instance);
            }
        }

    }

    public class Command
    {
        public string name;
        public Action<string[]> func;
        public string desc;
    }
}
