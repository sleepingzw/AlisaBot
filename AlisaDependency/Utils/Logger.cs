using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace AlisaDependency.Utils
{
    public static class Logger
    {
        public static void Log(string what,int level)//level 0 info 1 important 2 warning
        {
            
            AnsiConsole.Markup($"[green][[AlisaBot]][/] > {DateTime.Now}");
            switch (level)
            {
                case 0:
                    AnsiConsole.Markup($"[green] [[INFO]][/]");
                    break;
                case 1:
                    AnsiConsole.Markup($"[yellow] [[IMPORTANT]][/]");
                    break;
                case 2:
                    AnsiConsole.Markup($"[red] [[WARNING]][/]");
                    break;
            }
            AnsiConsole.Markup($" {what}\n");
        }
        public static void WriteException(Exception ex)
        {
            AnsiConsole.Markup($"[green][[AlisaBot]][/] > {DateTime.Now} [red][[WARNING]][/]\n");
            AnsiConsole.WriteException(ex,
                        ExceptionFormats.ShortenPaths | ExceptionFormats.ShortenTypes |
                        ExceptionFormats.ShortenMethods);
        }
    }
}
