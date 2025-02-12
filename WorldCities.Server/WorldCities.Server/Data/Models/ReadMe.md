Required modifier docs: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required

EF Core modeling documentation: https://learn.microsoft.com/en-us/ef/core/modeling/

There is a one-to-many relationship between Country and City classes. 

If / when we want to load the associated child City objects when the Country object is retrieved from the DB, we need to choose a loading pattern:
- Eager loading: The related data is loaded from the database as part of the initial query. 
- Explicit loading: The related data is explicitly loaded from the database at a later time.
- Lazy loading: The related data is transparently loaded from the database when the entity navigation property is accessed for the first time. This is the most complex pattern among the three and might suffer some serious performance penalties when not implemented properly.
By default, the `Cities` property of the retrieved `Country` object will be `null` unless we explicitly load it via EF Core.

Some examples demonstrating these patterns: 

```csharp
var country = await _context.Countries
    .FindAsync(id);
return country; // country.Cities is still set to null
```

```csharp
var country = await _context.Countries
    .Include(c => c.Cities) // fetch the country as well as all of the corresponding cities in a single query (based on the city's CountryId value equal to that country’s Id value) 
    .FindAsync(id);
return country; // country.Cities is (eagerly) loaded
```
Further documentation here: https://learn.microsoft.com/en-us/ef/core/querying/related-data/. Note the complexities associated with lazy loading, particularly around the N+1 loading problem.
