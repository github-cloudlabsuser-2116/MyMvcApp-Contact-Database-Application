// using System.Diagnostics; // Removed unnecessary using directive
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static List<User> userlist = new List<User>();

        // GET: User
    public ActionResult Index(){
        // Implement the Index method here
        return View(userlist);
    }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();

        }

        // POST: User/Create
        [HttpPost]
public ActionResult Create(User user)
{
    // Implement the Create method (POST) here
    if (ModelState.IsValid) 
    {
        userlist.Add(user);
        return RedirectToAction("Index");
    }
    return View(user);
}

        // POST: User/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(int id, User user)
{
    // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
    // It receives user input from the form submission and updates the corresponding user's information in the userlist.
    // If successful, it redirects to the Index action to display the updated list of users.
    // If no user is found with the provided ID, it returns a HttpNotFoundResult.
    // If an error occurs during the process, it returns the Edit view to display any validation errors.
    var existingUser = userlist.FirstOrDefault(u => u.Id == id);
    if (existingUser == null)
    {
        return NotFound();
    }
    if (ModelState.IsValid)
    {
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        return RedirectToAction("Index");   
    }
    return View(user);
}
    
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Implement the Edit method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            // Implement the Delete method (POST) here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");
        }

       public IActionResult Search(string query)
    {
        var results = userlist.Where(u => u.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                                          u.Email.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        return View("Index", results);
    }
}
