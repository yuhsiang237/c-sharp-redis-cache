# c-sharp-redis-cache
The project is a cache-service implement of id list.  
It improves your database performance by fetch data directly from your cache service instead of going through the database.  
When your database is updated, you just need to call refresh to reload the data.

### API SPEC

<table>
<tr>
<td>Method</td>
<td>API</td>
<td>Description</td>
<td>Response Example</td>
</tr>
<tr>
<td>GET</td>
<td>/Id/GetAll</td>
<td>Get All Id list.</td>
<td>[{"id":1,"remark":"Remark:380"},{"id":2,"remark":"Remark:753"}...]</td>
</tr>
<tr>
<td>GET</td>
<td>/Id/GetById?id=100</td>
<td>Get Id list by Id.</td>
<td>[{"id":100,"remark":"Remark:380"}</td>

</tr>
<tr>
<td>GET</td>
<td>/Id/Refresh</td>
<td>Refresh Id list cache</td>
<td>true</td>
</tr>
</table>
