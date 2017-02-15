using Android.App;
using Android.OS;
using Android.Widget;
using SQLiteDemo.Model;

namespace SQLiteDemo
{
    [Activity(Label = "SQLiteDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView _funcionariosListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var cmdSalvar = FindViewById<Button>(Resource.Id.cmdSalvar);

            _funcionariosListView = FindViewById<ListView>(Resource.Id.lstFuncionarios);

            using (var db = new Mydb())
            {
                _funcionariosListView.Adapter = new FuncionarioAdapter(db.Listar());
            }

            cmdSalvar.Click += delegate { Salvar(); };
        }

        private void Salvar()
        {
            var txtNome = FindViewById<EditText>(Resource.Id.txtNome);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            var txtCargo = FindViewById<EditText>(Resource.Id.txtCargo);

            var funcionario = new Funcionario { Nome = txtNome.Text, Email = txtEmail.Text, Cargo = txtCargo.Text };

            using (var db = new Mydb())
            {
                db.Insert(funcionario);
                _funcionariosListView.Adapter = new FuncionarioAdapter(db.Listar());
            }

            txtNome.Text = "";
            txtEmail.Text = "";
            txtCargo.Text = "";
        }
    }
}

