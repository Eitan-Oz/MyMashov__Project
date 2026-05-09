namespace AdminMashov_Control
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("students", typeof(AdminStudentsControl));
            Routing.RegisterRoute("teachers", typeof(AdminTControl));
            Routing.RegisterRoute("CoAdmin", typeof(AdminCoAdminControl));
        }
    }
}
