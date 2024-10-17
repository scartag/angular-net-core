# angular-net-core
Simple .NET Core / Angular App


## BACKEND INFO
To run the backend, please navigate to `Contacts/Contacts.Api` and then run `dotnet run`
The backend expects the RavenDb instance to be unsecured and have a database called `Contacts`

By default, it should run with the `appSettings.local.json` but be sure to check `appSettings.json` so it doesn't override your expected settings.

## FRONTEND INFO
To run the frontend, please navigate to `frontend` and then run `npm install`. if all goes well, run `npm start`

The default `apiUrl` is set in the `environment.ts` file.




