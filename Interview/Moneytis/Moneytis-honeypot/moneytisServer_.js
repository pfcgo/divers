var http = require('http');
var url = require('url');
var dispatcher = require('httpdispatcher');

// Dispatcher
function handleRequest(req, res){
    try {
        console.log(req.url);
        dispatcher.dispatch(req, res);
    } catch(err) {
        console.log(err);
    }
}

// Server creation
const PORT = 80;
const HOSTNAME = '127.0.0.1';
var server = http.createServer(handleRequest);
server.listen(PORT, HOSTNAME, function(){
    console.log("Server listening on: %s:%s", HOSTNAME, PORT);
});

// return true if request detected as coming from a scrapper
// reqTimestamp : crypted timestamp
// key : coded key
// res : just the answer to be passed to the callback
// cb : callback that will send the answer 
// Je pense qu'il y aurait un meilleur moyen de d'utiliser les callbacks pour éviter de devoir passer le res de callback en callback
function checkIfScrapper(reqTimestamp, key, res, cb)
{
	var isScrapper = false;
	
	if(reqTimestamp && key)
	{
		var decryptedTimestamp = reqTimestamp - 15015848648; // to be replaced by decryption using the key
		//console.log("decryptedTimestamp : %s", decryptedTimestamp);
		var currTimestamp = Date.now();
		//console.log("currTimestamp : %s", currTimestamp);
		var currTimestamp = Date.now();
		//console.log(currTimestamp - decryptedTimestamp);
		if(currTimestamp - decryptedTimestamp > 1000 || currTimestamp < decryptedTimestamp)
		{
			// to be refined but if the timestamp is more than one second old, probably a scrapper reusing an old request
			// and decryptedTimestamp can't be bigger than currTimestamp so probably an attempt to pass the scrapper detection
			isScrapper = true;
		}
	}
	else
	{
		// missing compulsory parameters
		isScrapper = true;
	}
	cb(isScrapper, res);
}

function sendResponse(isScrapper, res) {
	res.writeHead(200, {'Content-Type': 'text/plain', 'Access-Control-Allow-Origin': '*'}); // 'Access-Control-Allow-Origin': '*' : security risk but I do that just for easy testing
	if(isScrapper)
	{
		// alertRobot(infoRobot)
		res.write("SCRAPPER");
	}
	else{
		res.write("good guy");
	}
	res.end();
}

// Sensitive data request protected by a honeypot 
dispatcher.onGet("/api/ExchangeRates", function(req, res) {
    console.log("req : %s", req.url);
	var queryData = url.parse(req.url, true).query;
	
	var reqTimestamp = queryData.t128s;
	var cryptedKey = queryData.c256y;
	
	checkIfScrapper(reqTimestamp, cryptedKey, res, sendResponse);
});