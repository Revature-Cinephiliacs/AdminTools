# AdminTools

## Available Requests

baseURL: the deployment url

---

<ol>
    <li>POST request:
    <ul>
        <li>{baseURL}/Reports</li>
        <li>
        <b>REQUIRED</b> Body: </br>
        <pre>
        <code>
        {
            string ReportEntityType
            string ReportDescription
            string ReportEnitityId
        }
        </code>
        </pre>
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
</ol>
