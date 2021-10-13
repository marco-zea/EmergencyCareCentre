# EmergencyCareCentre

#Requirements
1. Sql Server (update connection string in appsetting.json file in webapi project).
2. Net core 5 SDK.
3. Postman

#Steps
1. Clone this repo locally
2. Build and keep running WepApi. 
3. Database and initial data for beds and patients is added.
4. Build and run WebApp.
5. You can use postman to test webapi endpoints.

#Things to know
- As expected 4 hours won't be enough to get the right solution running.
- As I need to think about if I required adding things for:
  - Database desing: I was struggling if using relational or document structure.
  - Security: Authentication and Authorization.
  - DataTransit issues: using polly to handle transient issue.
  - Handling errors: web api responses and web app behaviour.  
- No creating form but sending same data object to admit, comment and discharge to see the behaviour.
- Using bootstrap table class.
- Click on patient's name to see details.
- Not using service at this moment for statistics.

#Assumptions
- Not thinking in performance.
- Faking posting data to admit, add comment and discharge.
- Separation to other services (interfaces) not included at this stage.
  
#TODO - no included
- Unit and Integration tests.

Thanks for the opportunity and your time in allowing me applying for this role.

FUNCTIONAL.


