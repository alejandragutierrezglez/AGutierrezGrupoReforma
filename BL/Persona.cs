using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Persona
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezGrupoReformaContext context = new DL.AgutierrezGrupoReformaContext())
                {
                    var query = context.Personas.FromSqlRaw($"PersonaGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Persona persona = new ML.Persona();
                            persona.IdPersona = obj.IdPersona;
                            persona.Nombre = obj.Nombre;
                            persona.Direccion = obj.Direccion;
                            persona.Edad = obj.Edad.Value;
                            persona.Correo = obj.Correo;
                            persona.Habilidades = obj.Habilidades;
                            persona.IdTipo = obj.IdTipo.Value;

                            result.Objects.Add(persona);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;

            }
            return result;
        }

        public static ML.Result Add(ML.Persona persona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezGrupoReformaContext context = new DL.AgutierrezGrupoReformaContext())
                {
                    // var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    var query = context.Database.ExecuteSqlRaw($"PersonaAdd '{persona.Nombre}', '{persona.Direccion}', {persona.Edad},'{persona.Correo}','{persona.HabilidadPrincipal}','{persona.HabilidadSecundaria}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Persona persona)
        {
            using (DL.AgutierrezGrupoReformaContext context = new DL.AgutierrezGrupoReformaContext())
            {
                Result result = new ML.Result();
                try
                {

                    //var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    var query = context.Database.ExecuteSqlRaw($"PersonaUpdate {persona.IdPersona}, '{persona.Nombre}', '{persona.Direccion}',{persona.Edad},'{persona.Correo}','{persona.HabilidadPrincipal}','{persona.HabilidadSecundaria}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }

        public static ML.Result Delete(int IdPersona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezGrupoReformaContext context = new DL.AgutierrezGrupoReformaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PersonaDelete {IdPersona}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result GetById(int IdPersona)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AgutierrezGrupoReformaContext context = new DL.AgutierrezGrupoReformaContext())
                    {
                        var query = context.Personas.FromSqlRaw($"PersonaGetById {IdPersona}").AsEnumerable().FirstOrDefault();

                        if (query != null)
                        {
                            ML.Persona persona = new ML.Persona();

                            persona.IdPersona =query.IdPersona;
                            persona.Nombre = query.Nombre;
                            persona.Direccion = query.Direccion;
                            persona.Edad = query.Edad.Value;
                            persona.Correo = query.Correo;
                            persona.Habilidades = query.Habilidades;
                            persona.IdTipo = query.IdTipo.Value;

                            result.Object = persona;

                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }


    }
}