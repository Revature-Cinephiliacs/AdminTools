# AdminTools

## Available Requests

<code>baseURL</code> -- the deployment url

---

<ol>
    <li>POST request:
    <ul>
        <li>Endpoint: <code>{baseURL}/Reports</code></li>
        <li>
        <b>REQUIRED</b> Body: </br>
<pre><code>{
    int ReportId // optional if exists
    string ReportEntityType
    string ReportDescription
    string ReportEnitityId
    DateTime ReportTime // optional if exists
}</code></pre>
        </li>
        <li><code>ReportEntityType</code> can be:
        <ul>
            <li>
            <code>Review</code>, <code>User</code>, <code>Movie</code>, <code>Group</code> or <code>Forum.</code>
            </li>
        </ul>
        </li>
    </ul>
    </li>
</ol>
