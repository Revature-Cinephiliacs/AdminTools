# AdminTools

## Available Requests

baseURL: the deployment url

---

<ol>
    <li>
    <pre>
    POST request:
    {baseURL}/Reports
    <b>REQUIRED</b> Body: </br>
    <code>
{
    string ReportEntityType
    string ReportDescription
    string ReportEnitityId
}
    </code>
    ReportEntityType can be:
    <samp>
        Review, User, Movie, Group or Forum.</samp></pre>
    </li>
</ol>
