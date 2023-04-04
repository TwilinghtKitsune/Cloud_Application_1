using Cloud_Application_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cloud_Application_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _logger;
        CloudApplicationBdContext db;

        public HomeController(IWebHostEnvironment logger, CloudApplicationBdContext context)
        {
            _logger = logger;
            db = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Character> characters = db.Characters;
            IEnumerable<Master> masters = db.Masters;
            ViewBag.Characters = characters;
            ViewBag.Masters = masters;
            return View();
        }

        [HttpGet]
        public ActionResult Open(int id)
        {
            ViewBag.Character = db.Characters.Find(id);
            return View("Character");
        }

        [HttpGet]
        public ActionResult Сhange(int id)
        {
            ViewBag.Editor = db.Characters.Find(id);
            IEnumerable<Master> masters = db.Masters;
            ViewBag.Masters = masters;
            ViewBag.New = false;
            return View("Editor");
        }

        [HttpGet]
        public ActionResult Сhange_Delete(int id)
        {
            
            return RedirectToAction("Сhange", "Home", new { id = id });
        }

        [HttpPost]
        public ActionResult Сhange(Character сharacter)
        {
            db.Characters.Find(сharacter.Id).Name = сharacter.Name;
            db.Characters.Find(сharacter.Id).Race = сharacter.Race;
            db.Characters.Find(сharacter.Id).Lvl = сharacter.Lvl;
            db.Characters.Find(сharacter.Id).Description = сharacter.Description;
            db.Characters.Find(сharacter.Id).Master = сharacter.Master;
            db.SaveChanges();
            return RedirectToAction("Open", "Home", new { id = сharacter.Id });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Character character = db.Characters.Find(id);
            if (character != null)
            {
                db.Characters.Remove(character);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCharacter()
        {
            Character character = new Character();
            IEnumerable<Master> masters = db.Masters;
            ViewBag.Editor = character;
            ViewBag.Masters = masters;
            ViewBag.New = true;
            return View("Editor");
        }

        [HttpPost]
        public ActionResult AddCharacter(Character сharacter)
        {
            db.Characters.Add(сharacter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddMaster()
        {
            ViewBag.Master = new Master();
            return View("EditorMaster");
        }

        [HttpPost]
        public ActionResult AddMaster(string name)
        {
            Master master = new Master();
            master.Name = name;
            db.Masters.Add(master);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult СhangeMaster(int id)
        {
            ViewBag.Master = db.Masters.Find(id);
            return View("EditorMaster");
        }

        [HttpPost]
        public ActionResult СhangeMaster(string name, int id)
        {
            db.Masters.Find(id).Name = name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMaster(int id)
        {
            Master master = db.Masters.Find(id);
            if (master != null)
            {
                db.Masters.Remove(master);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}