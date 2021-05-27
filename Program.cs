using System;

namespace DigitalInovattionExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Alunos[] alunos = new Alunos[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuário();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Alunos aluno = new Alunos();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }                                              

                        else
                        {
                            throw new ArgumentException("Valor deve ser do tipo decimal!");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;
                        if(mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO GERAL: {conceitoGeral}");


                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuário();
            }
        }

        private static string ObterOpcaoUsuário()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair do programa");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
