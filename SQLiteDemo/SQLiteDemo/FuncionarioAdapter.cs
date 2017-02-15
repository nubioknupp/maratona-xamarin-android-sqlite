using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Widget;
using SQLiteDemo.Model;

namespace SQLiteDemo
{
    public class FuncionarioAdapter : BaseAdapter<Funcionario>
    {
        private readonly List<Funcionario> _funcionarios;

        public FuncionarioAdapter(List<Funcionario> funcionarios)
        {
            _funcionarios = funcionarios;
        }

        public override int Count => _funcionarios.Count;

        public override Funcionario this[int position] => _funcionarios[position];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.FuncionarioItem, parent, false);
            var txtNome = view.FindViewById<TextView>(Resource.Id.txtNome);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.txtEmail);
            var txtCargo = view.FindViewById<TextView>(Resource.Id.txtCargo);

            txtNome.Text = _funcionarios[position].Nome;
            txtEmail.Text = _funcionarios[position].Email;
            txtCargo.Text = _funcionarios[position].Cargo;

            return view;
        }

    }
}