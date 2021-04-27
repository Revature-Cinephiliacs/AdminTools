# AdminTools

## Available Requests

baseURL: the deployment url

---

<ol>
    <li>POST request:
    <ul>
        <li>Endpoint: <code>{baseURL}/Reports</code></li>
        <li>
        <b>REQUIRED</b> Body: </br>
<pre><code>{
    string ReportEntityType
    string ReportDescription
    string ReportEnitityId
}</code></pre>
        </li>
        <li>ReportEntityType can be:
        <ul>
            <li>
            <code>Review, User, Movie, Group or Forum.</code>
            </li>
        </ul>
        </li>
    </ul>
    </li>
</ol>
