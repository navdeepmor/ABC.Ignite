namespace ABC.Ignite.Controllers;

[Route("api/classes")]
public class ClassesController : BaseApiController
{
    public readonly IClassesService classesService;

    public ClassesController(IClassesService classService) 
    {
        this.classesService = classService;
    }


    [HttpPost]
    public ActionResult<Class> PostClass([FromBody] Class newClass)
    {
        var classResult = this.classesService.CreateClass(newClass);
        return CreatedAtAction(nameof(PostClass), newClass);
    }
}
