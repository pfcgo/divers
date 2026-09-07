var http = require('http');
var url = require('url');
var cheerio = require('cheerio');
var fs = require('fs');




var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('schools_end_url.txt')
});

var csvResult = 'Ecole, email\n';

function getSchoolPage(schools_end_url)
{
	var aefeBase = 'http://www.aefe.fr/reseau-scolaire-mondial/rechercher-un-etablissement/'
	/*{
	  host: 'www.aefe.fr',http://www.aefe.fr/reseau-scolaire-mondial/rechercher-un-etablissement/
	  path: '/reseau-scolaire-mondial/rechercher-un-etablissement/'
	};*/

	fetchInfo = function(response) {
	  var schoolPage = '';

	  //another chunk of data has been recieved, so append it to `schoolPage`
	  response.on('data', function (chunk) {
		  // todo : if starts with '//' skip
		schoolPage += chunk;
	  });
	  
	  
	  
	  
	  
	  
	  //the whole response has been recieved, so we fetch the infos we want
	  response.on('end', function () {
			$ = cheerio.load(schoolPage);
			csvResult += schools_end_url;
			csvResult += ', ';
			
			// phone
			
			// ... TODO : s'inspirer de //url pour selectionner les parties qu'on veut
			
			// url
            $('div .field-name-field-ets-website .field-items .field-item a').each(function(i, elem) {
				var url = $(this).attr('href');
				csvResult += url;
				console.log('url:', url);
            });
			
			
			
			csvResult += '\n'; // we put the \n' outside so in case the info is missing, the csv is still correct
			
			
			
		 
		//console.log(schoolPage);
		console.log(csvResult); // will display the full csv each time
	  });
	}

	var shcool_url = aefeBase+schools_end_url;
	console.log('Requesting:', shcool_url);
	http.request(shcool_url, fetchInfo).end();
}

function saveCSV()
{
	// todo : save csv to file when all html pages has been treated
}

lineReader.on('line', function (line) {
  getSchoolPage(line);
});

getSchoolPage('afrique-du-sud-johannesburg-lycee-francais-jules');