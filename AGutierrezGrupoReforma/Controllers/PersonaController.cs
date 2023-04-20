using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PersonaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
         
            ML.Persona persona = new ML.Persona();
            ML.Result result = BL.Persona.GetAll();
            

            if (result.Correct)
            {
                persona.Personas = result.Objects;
                return View(persona);
            }
            else
            {
                return View(persona);
            }
        }




        [HttpGet]
        public IActionResult Form(int? IdPersona)
        {
            ML.Result resultPersona = BL.Persona.GetAll();

            ML.Persona persona = new ML.Persona();

            if (resultPersona.Correct)
            {

                persona.Personas = resultPersona.Objects;
            }
            if (IdPersona == null)
            {
                //add //formulario vacio
                return View(persona);
            }
            else
            {
                //getById
                ML.Result result = BL.Persona.GetById(IdPersona.Value); //2


                if (result.Correct)
                {
                    persona = (ML.Persona)result.Object;//unboxing
                    persona.Personas = resultPersona.Objects;
                    //update
                    return View(persona);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información de la aseguradora";
                    return View("Modal");
                }
            }
        }

        [HttpPost] //Hacer el registro

        public ActionResult Form(ML.Persona persona)
        {
            ML.Result result = new ML.Result();

            if (persona.IdPersona != null)
            {
                //UPDATE                   
                result = BL.Persona.Update(persona);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                //Add                 
                result = BL.Persona.Add(persona);
                ViewBag.Message = "Se ha agregado el registro";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }

        public ActionResult Delete(int IdPersona)
        {
            //ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);
            ML.Result result = new ML.Result();

            result = BL.Persona.Delete(IdPersona);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro seleccionado" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
    }
}
