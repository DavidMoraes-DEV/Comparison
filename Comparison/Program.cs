using System;
using System.Collections.Generic;
using Comparison.Entities;

namespace Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * COMPARISON<T>
            - É um delegate e sua declaração é:
                - public delegate int Comparison<in T>(T x, T y); e isso é uma declaração de assinatura de função. Pegando uma função "qualquer" que recebe dois objetos do tipo "T" e retorna um numero inteiro. (Como no exemplo da função criada abaixo (CompareProducts) que faz exatamente isso. Por isso que a chamada por delegate pôde ser casada no método .Sort() por exemplo.
                - Ou seja, ele é um tipo genérico do tipo "T" recebendo dois objetos (X e Y) e retorna um int


            * PROBLEMA EXEMPLO:
            - Suponha uma classe Product com os atributos name e price.
            - Suponha que precisamos ordenar uma lista de objetos Product.
            - Podemos implementar a compração de produtos por meio da implementação da interface IComparable<Product>
            - Entretando, desta forma nossa classe não fica fechada para alteração: se o critério de compração mudar, precisaremos alterar a classe Product.
            - Podemos então usar outra sobrecarga do método "Sort" da classe List: EXEMPLO: public void Sort(Comparison<T> comparison)
            */

            List<Product> list1 = new List<Product>();

            list1.Add(new Product("TV", 900.0));
            list1.Add(new Product("Notebook", 1200.0));
            list1.Add(new Product("Tablet", 450.0));

            List<Product> list2 = new List<Product>();

            list2.Add(new Product("TV 4K", 1500.0));
            list2.Add(new Product("Computer", 2000.0));
            list2.Add(new Product("SmartPhone", 1300.0));

            List<Product> list3 = new List<Product>();

            list3.Add(new Product("HeadSet", 1600.0));
            list3.Add(new Product("Mouse", 200.0));
            list3.Add(new Product("DVD", 280.0));

            //Refrência simples de método como parâmetro:

            list1.Sort(CompareProducts); //Colocar o nome da função como parâmetro é como colocar uma referência para essa função sem os "()" colocando simplismente o nome da função e isso em C# é conhecido como DELEGATE, e delegate é uma referência para uma função com tipesafyt

            Console.WriteLine("List1:");
            foreach (Product p in list1)
            {
                Console.WriteLine(p);
            }

            //Referência de método atribuído a uma variável tipo delegate:

            Comparison<Product> comp1 = CompareProducts; //Também é possível fazer uma variável do tipo Comparison receber o returno e depois colocar apenas o nome da variável no método .Sort()
            list2.Sort(comp1); //Ao invés de colocar a referência para a função (Nesse caso seria: CompareProducts) é possível colocar uma variável do tipo Comparison que recebeu a referência da função.

            Console.WriteLine("\nList2:");
            foreach (Product p in list2)
            {
                Console.WriteLine(p);
            }

            /* Sendo possível ainda ao ínves de criar uma função separada para depois chamar sua referência, podemos simplismente criar uma expressão LAMBDA
            * Expressão Lambda
            - É uma função Anônima, ou seja, ela não precisa ser declarada.
            */

            //Expressão lambda atribuída a uma variável tipo delegate:

            Comparison<Product> comp2 = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()); //Expressão Lambda (função anônima) sendo que o operador de função é: "=>" e em seguinda vem a expresão desejada que seja a resultante dos dois argumentos colocar entre parênteses(p1, p2). Sendo que a lógica aplicada foi a mesma da função declarada (CompareProducts) porém na expressão lambda como é uma função anônima não é necessário declara-la completamente igual a outra função
            list3.Sort(comp2);

            /*
            expressão lambda inline:
            List3.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));    Vale ressaltar que é possível colocar a expressão lambda diretamente como argumento da função .Sort()
            */

            Console.WriteLine("\nList3:");
            foreach (Product p in list3)
            {
                Console.WriteLine(p);
            }
        }

        static int CompareProducts(Product p1, Product p2) //Função que compara dois Products e retorna um número inteiro
        {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
