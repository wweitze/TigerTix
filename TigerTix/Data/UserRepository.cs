using System;



public class UserRepository
{
	private readonly TigerTixContext _context;

	public UserRepository( TigerTixContext context)
	{
		_context = context;
	}

	//Save a user
	public void SaveUser (User user)
    {
		_context.Add(user);
		_context.SaveChanges();
    }

	//Returns all users
	public IEnumerable<UserRepository> GetAllUsers()
    {
		var users = from u in _context.Users
					select u;
		return users.ToList();
    }

	public User GetUsersByID(int userID)
    {
		var user = (from u in _context.Users
					where u.Id == userID
					select u).FirstOrDefault();
		return user;
    }

	//Update a user
	public void UpdateUser(User user)
    {
		_context.Update(user);
		_context.SaveChanges();
    }

	//Delete a user
	public void DeleteUser(User user)
    {
		_context.Remove(user);
		_context.SaveChanges();
    }
}
