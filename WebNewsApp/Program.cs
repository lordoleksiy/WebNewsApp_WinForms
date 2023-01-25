using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.Controllers;
using WebNewsApp.Views;

namespace WebNewsApp
{
    public static class Program
    {   
        public static IKernel Kernel { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Kernel = new StandardKernel();
            Kernel.Load(new NinjectDependency());

            var window = new MainWindow();
            new MainPresenter(window);
            Application.Run(window);

        }
    }
}
