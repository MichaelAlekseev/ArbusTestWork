using System.Net.Http;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpclient = new HttpClient();
            using CancellationTokenSource tokenSource = new CancellationTokenSource(2_000);

            /*using CancellationTokenSource tokenSource = new CancellationTokenSource(2_000)
             *является важным элементом, без которого задача не может быть выполнена, именно токен отмены задает некий аналог if-else, который работает в блоке try-catch-finally
             *Ну и, соответственно, использование конструктора GetAsync(String, CancellationToken) также является необходимым. Отсутствие токена в методе GetAsync может привести
             *к бесконечно долгому ожиданию ответа от сервера без исключений, следовательно код не перейдет в блок catch и не сможет ничего обработать.*/

            try
            {
                httpclient.GetAsync("https://google.com:4552", tokenSource.Token).GetAwaiter().GetResult(); //Отсутствие ответа от сервера не является ошибкой задания
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}
