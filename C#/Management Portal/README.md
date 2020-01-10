I began my two week sprint in the Management Portal project in the middle of it's lifecycle.
It is a software project that will manage a collection of jobs. Users will be able to keep track of which job(s) they are assigned to and see company news and posts as well as chat with other users via the internet on mobile or computer platforms. I was able to introduce new aspects to the project as well as improve the functionality of previous stories.

DEACTIVATE JOB BUTTON FROM DASHBOARD
This project has a dashboard that offers a quick overview of most aspects of the user’s jobs. The Activate Job button that only Admin see was already created in the dashboard view.
Established the Deactivate Job button to match the Activate Job button in the dashboard view.
Modified the existing code for the Activate Button to also deactivate jobs depending on the button pushed.

DEBUG NEWS POP-UP
When creating a new News Story from the dashboard, if you were in an Admin role, an error would happen. This error didn’t start until implementation of the form for creating a news item using a modal.
An Exception User-Unhandled error was thrown.
Research showed that the Get method was not allowing posts from admin.
Modified the [HTTP POST] to [AcceptVerbs(HttbVerbs.Post | HttpVerbs.Get)]
