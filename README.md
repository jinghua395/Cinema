# Cinema

Background

The owners of a Cinema theater have contracted you to develop the backend of a new app, targeted both customers and internal staff. The app should include several features for a given cinema room.When developing the application, the clients is especially interested in ensuring the following:
- The application is expected to be developed further over time. Make sure this can be done without introducing new errors to the existing features.
- Not all users are expected to be IT experts. Therefore, make sure that invalid inputs are handled properly and users are guided well.
- Not all seats are equal! If the capacity is over 50 people, the front half rows cost $12, the back half cost $10. If capacity 50 or below, all cost $10


Features
Build a console application in Java or C#, that implements the following features:

- Receive inputs for “number of rows” and “number of seats per row” for the given cinema room.
- Show an output of the seats and their status (“A” for available, “R” for reserved)
- Buy a ticket for a specific seat. The user should be able to choose which seat, however only available ones.
- Output metrics for the cinema room, including:
  - number of purchased tickets
  - percentage occupied
  - Current income (sum of reserved tickets)
  - Potential total income (sum of all available and reserved tickets)

When the application starts up, the user should be able to choose which action to take. Only upon actively choosing to stop the app, should the application end the runtime.
