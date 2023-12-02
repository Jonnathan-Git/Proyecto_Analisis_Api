namespace AnalisisProyecto.Models.Logic {
    using System;
    using System.IO;

    public class Logger {

        public static void LogError(string filePath, string message) {
            Log("ERROR", message, filePath);
        }

        public static void LogInfo(string filePath, string message) {
            Log("INFO", message, filePath);
        }

        private static void Log(string logLevel, string message, string filePath) {
            try {
                // Formato del registro: [Fecha y hora] [Nivel de log] [Mensaje]
                string logEntry = $"{DateTime.Now} [{logLevel}] {message}";

                // Escribir en el archivo
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
            } catch (Exception ex) {
                // Manejar cualquier error al escribir en el archivo de logs
                Console.WriteLine($"Error al escribir en el archivo de logs: {ex.Message}");
            }
        }
    }
}
