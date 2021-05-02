# AdminTools

## Available Requests

Endpoints can only be called by an **Admin** user
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
            <code>Review</code>, <code>Comment</code>, <code>Discussion</code>.
            </li>
        </ul>
        </li>
    </ul>
    </li>
    <li>GET request:
    <ul>
        <li>Endpoint: <code>{baseURL}/Tickets</code></li>
        <li>Returns: <code>List of TicketItem</code></li>
        <li><code>TicketItem</code> object:
        <ul><li>
<pre><code>TicketId: int // optional please don't give this
ItemId: string // the id of thing being reported
AffectedService: string // can be only one of ReportEntityType
Descript: string 
TimeSubmitted: DateTime //optional
Item: dynamic</code></pre></li>
        </ul>
        </li>
    </ul>
    </li>
</ol>
