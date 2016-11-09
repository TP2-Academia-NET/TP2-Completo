using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    class ModuloUsuarioAdapter : Adapter
    {
        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modUs = new ModuloUsuario();

            try
            {
                sqlConn = this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmdModulosUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                if (drModulosUsuarios.Read())
                {
                    modUs.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUs.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUs.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUs.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modUs.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modUs.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modUs.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de MóduloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modUs;
        }

        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulosUsuarios = new List<ModuloUsuario>();

            try
            {
                sqlConn = this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", sqlConn);
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modUs = new ModuloUsuario();

                    modUs.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUs.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUs.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUs.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modUs.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modUs.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modUs.PermiteConsulta = (bool)drModulosUsuarios["consulta"];

                    modulosUsuarios.Add(modUs);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de MódulosUsuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosUsuarios;
        }

        public void Delete(int ID)
        {
            try
            {
                sqlConn = this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar MóduloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                sqlConn = this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET id_modulo = @id_modulo, id_usuario = @id_usuario, alta = @alta, baja = @baja, modificacion = @modificacion, consulta = @consulta WHERE id_modulo = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del MóduloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                sqlConn = this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta) values(@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = moduloUsuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = moduloUsuario.PermiteConsulta;
                moduloUsuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear MóduloUsuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(moduloUsuario.ID);
            }
            else if (moduloUsuario.State == BusinessEntity.States.New)
            {
                this.Insert(moduloUsuario);
            }
            else if (moduloUsuario.State == BusinessEntity.States.Modified)
            {
                this.Update(moduloUsuario);
            }
            moduloUsuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
