namespace AppNomina
{
    public interface IPersistencia 
    {
        void GuardarEmpleado(Empleado empleado);
        void EliminarEmpleado(int id);

        void EliminarEmpleado(Empleado empleado);
        //void ActualizarEmpleado(int id, Empleado empleado);
        List<Empleado> GetEmpleados();


        void GuardarDetalleNomina(DetalleNomina nomina);
        void EliminarDetalleNomina(int id);

        void EliminarDetalleNomina(DetalleNomina nomina);
        //void ActualizarDetalleNomina(DetalleNomina nomina, int id);
       List<DetalleNomina> GetDetalleNomina();

        void GuardarRegistroLaboral(RegistroLaboral registro);
        void EliminarRegistroLaboral(RegistroLaboral registro);

        void EliminarRegistroLaboral(int id);
        //void ActualizarRegistroLaboral(RegistroLaboral nomina, int id);
        List<RegistroLaboral> GetRegistroLaborals();
        public void printNomina();
        void archivotxtNomina();
    }

}