using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System.Net.Http;
using System.Threading;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstace)
        {
            base.OnCreate(savedInstace);
            var httpclient = new HttpClient();
            CancellationTokenSource tokenSource = new CancellationTokenSource(2_000); //Ответ на вопрос 3: Создаем переменную вне контекста инструкции using.
            using (tokenSource)  
            {
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
            SetContentView(Resource.Layout.activity_main); /*Ответы на вопросы 1. и 2.:
                                                            * инструкция using создает контекст в котором существует переменная tokenSource, в указанной точке кода в соответствии с принципами ООП 
                                                            * переменная tokenSource перестает существовать и не может быть в дальнейшем использована. В случае попытки обращения к ней
                                                            * среда разработки укажет на ошибку, что tokenSource не существует в данном контексте */
        }
    }
}