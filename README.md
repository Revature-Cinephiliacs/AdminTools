# AdminTools

## Available Requests

baseURL: the deployment url

---

<ul>
    <li>POST request:
    <ul>
        <li>{baseURL}/Reports</li>
        <li>
        <b>REQUIRED</b> Body:
        ```
        {
            string ReportEntityType
            string ReportDescription
            string ReportEnitityId
        }
        ```
        </li>
        <li>ReportEntityType can be:
        <ul>
            <li>
            Review, User, Movie, Group or Forum.
            </li>
        </ul>
        </li>
    </ul>
    </li>
    <li></li>
</ul>
