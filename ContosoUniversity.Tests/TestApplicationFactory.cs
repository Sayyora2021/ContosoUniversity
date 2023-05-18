using Microsoft.AspNetCore.Mvc.Testing;



namespace ContosoUniversity.Tests
{
    /* Pour la visibilité sur la classe internal Program, 
     * il faut rendre cette classe publique à l’aide 
     * d’une déclaration de classe partielle

        public partial class Program { }

     * Cette déclaration est ici placée à la fin 
     * du fichier Program.cs
     */
    public class TestApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _environment = "Development";



        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(_environment);



            base.ConfigureWebHost(builder);
        }
    }
}



