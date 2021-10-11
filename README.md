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

#Assumptions
- As expected 4 hours won't be enough to get the right solution running.
- As I need to think about if I required adding things for:
  - Database desing: I was struggling if using relational or document structure.
  - Security: Authentication and Authorization.
  - DataTransit issues: using polly to handle transient issue.
  - Handling errors: web api responses and web app behavior.
  
#TODO
- Connecting webapp controller/actions and service to web api.
- CSS give a better look and manage modern UI concepts.
- Unit and Integration tests.
- Build Forms to Admit, add Comment and Discharge.

Thanks for the opportunity and your time in allowing me applying for this role.

NOT COMPLETED. STILL IN PROGRESS.
