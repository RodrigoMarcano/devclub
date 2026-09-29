using System;
using System.IO;
using Spire.Doc;

namespace DocxToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CONVERSOR DOCX PARA PDF ===\n");

            // Verificar argumentos de linha de comando
            if (args.Length >= 2)
            {
                ConvertDocument(args[0], args[1]);
                return;
            }

            // Modo interativo
            Console.Write("Digite o caminho completo do arquivo DOCX: ");
            string? inputFile = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputFile) || !File.Exists(inputFile))
            {
                Console.WriteLine("Arquivo não encontrado ou caminho inválido!");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o caminho para salvar o PDF (ou pressione Enter para usar mesmo nome): ");
            string? outputFile = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(outputFile))
            {
                outputFile = Path.Combine(
                    Path.GetDirectoryName(inputFile) ?? Directory.GetCurrentDirectory(),
                    Path.GetFileNameWithoutExtension(inputFile) + ".pdf"
                );
                Console.WriteLine($"Usando: {outputFile}");
            }

            ConvertDocument(inputFile, outputFile);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void ConvertDocument(string inputPath, string outputPath)
        {
            try
            {
                Console.WriteLine("\nIniciando conversão...");

                // Verificar se o arquivo de entrada existe
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Erro: Arquivo de entrada não encontrado: {inputPath}");
                    return;
                }

                // Garantir que o diretório de saída existe
                string? outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Carregar documento DOCX
                using (Document document = new Document())
                {
                    Console.WriteLine("Carregando documento...");
                    document.LoadFromFile(inputPath);

                    Console.WriteLine("Convertendo para PDF...");
                    document.SaveToFile(outputPath, FileFormat.PDF);

                    Console.WriteLine($"✓ Conversão concluída com sucesso!");
                    Console.WriteLine($"PDF salvo em: {outputPath}");

                    // Verificar tamanho do arquivo
                    FileInfo pdfInfo = new FileInfo(outputPath);
                    if (pdfInfo.Exists)
                    {
                        Console.WriteLine($"Tamanho do PDF: {(pdfInfo.Length / 1024.0):F2} KB");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Erro durante a conversão:");
                Console.WriteLine($"Mensagem: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalhes: {ex.InnerException.Message}");
                }
            }
        }
    }
}