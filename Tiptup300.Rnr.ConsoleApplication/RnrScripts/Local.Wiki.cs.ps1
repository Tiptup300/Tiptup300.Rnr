return @{
    Title = "Wikipedia API Search";
    desc  = "Searches Wikipedia for a page and returns the text output to the console.";
    Function  = {
        
        # Get the search query from arguments
        $query = GetArg "Query";

        # Define the API endpoint and parameters for search
        $endpoint = "https://en.wikipedia.org/w/api.php"
        $params = @{
            action   = "query";
            list     = "search";
            srsearch = $query;
            format   = "json"
        }

        Write-Host "Searching Wikipedia for: $query"
        
        $response = Invoke-RestMethod -Uri $endpoint -Method GET -ContentType "application/json" -Body $params
        
        # Check if any search results were found
        if ($response.query.search.count -gt 0) {
            # Get the page ID of the first search result
            $pageId = $response.query.search[0].pageid
            
            # Construct the URI to fetch the full page content
            $uri = "$($endpoint)?action=query&prop=extracts&pageids=$pageId&format=json"
            
            Write-Host "Fetching full content from: $uri"

            # Fetch the full page content
            $pageContent = Invoke-RestMethod -Uri $uri -Method GET -ContentType "application/json"

            $content = (rcs Local.ConvertHtmlToText --Html $pageContent.query.pages.$pageId.extract)
            
            rcs UtilityScripts.Misc.DisplayText --Content $content
        }
        else {
            # Inform the user that no results were found
            Write-Host "No Wikipedia pages found for the query: $query."
        }
    }
}
