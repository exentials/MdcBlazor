/*********************************************************************************
 *  This script extract all Google Roboto Fonts ad Material Icons with their CSS
 *  fixed to run in a local server. To update execute from the command line:
 *  
 *  npm run fonts 
 */

const path = require("path");
const https = require('https');
const fs = require('fs');

function extractRobotoFonts(url, destPath, destFile) {
    const destCss = path.resolve(destPath + "/" + destFile);
    console.log("Extact: ", url);

    const file = fs.createWriteStream(destCss);

    // Set useragent string to get .woff2 font format instead of .ttf
    const options = {
        headers: { 'User-Agent': 'AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88' }
    };

    const request = https.get(url, options, function (response) {
        response.pipe(file);
    });
    request.on("close", () => {
        var css = fs.readFileSync(destCss).toString("utf8");

        const regexNames = /\/\*\s(?<name>.*)\s\*\//g;

        let match;
        var names = [];
        do {
            match = regexNames.exec(css);
            if (match) {
                names.push(match.groups["name"]);
            }
        } while (match);

        const regex = new RegExp("(?<attribute>font-family|font-weight|src): (?<value>.*);", "g");
        var items = [];
        while ((match = regex.exec(css)) !== null) {
            items.push(match.groups);
        }
        for (var n = 0, i = 0; n < names.length; n++) {
            var fontName = names[n].replace(/'/g, "").replace(/ /g, "_").toLowerCase();

            let fontFamily = "";
            let fontWeight = "";
            let fontUrl = "";
            let fontExt = "";

            for (var c = 0; c < 3; c++, i++) {

                var item = items[i];

                if (item.attribute === 'font-family') {
                    fontFamily = item.value.replace(/'/g, "").replace(/ /g, "_").toLowerCase();
                } else if (item.attribute === 'font-weight') {
                    fontWeight = item.value;
                } else if (item.attribute === 'src') {
                    fontUrl = item.value.match(/url\((?<url>.*)\) /).groups["url"];
                    fontExt = fontUrl.split(".").slice(-1)[0];
                }
            }

            const destFontName = fontFamily + "_" + fontName + "_" + fontWeight + "." + fontExt;
            const destFont = path.resolve(destPath + "/" + destFontName);

            const fontFile = fs.createWriteStream(destFont);
            https.get(fontUrl, options, function (response) {
                response.pipe(fontFile);
            });

            css = css.replace(fontUrl, destFontName);
        }
        fs.writeFileSync(destCss, css);
    });
}

function extractMaterialIconFonts(url, destPath, destFile) {
    const destCss = path.resolve(destPath + "/" + destFile);
    console.log("Extact: ", url);

    const file = fs.createWriteStream(destCss);

    // Set useragent string to get .woff2 font format instead of .ttf
    const options = {
        headers: { 'User-Agent': 'AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88' }
    };

    const request = https.get(url, options, function (response) {
        response.pipe(file);
    });
    request.on("close", () => {

        var css = fs.readFileSync(destCss).toString("utf8");

        const regex = new RegExp("(?<attribute>font-family|font-weight|src): (?<value>.*);", "g");
        let match;
        var items = [];
        while ((match = regex.exec(css)) !== null) {
            items.push(match.groups);
        }


        for (var i = 0; i < items.length;) {

            let fontFamily = "";
            let fontWeight = "";
            let fontUrl = "";
            let fontExt = "";

            var item = items[i++];
            if (item.attribute === 'font-family') {
                fontFamily = item.value.replace(/'/g, "").replace(/ /g, "_").toLowerCase();
            } else {
                break;
            }
            item = items[i++];
            if (item.attribute === 'font-weight') {
                fontWeight = item.value;
            } else {
                break;
            }
            item = items[i++];
            if (item.attribute === 'src') {
                fontUrl = item.value.match(/url\((?<url>.*)\) /).groups["url"];
                fontExt = fontUrl.split(".").slice(-1)[0];
            } else {
                break;
            }

            const destFontName = fontFamily + "_" + fontWeight + "." + fontExt;
            const destFont = path.resolve(destPath + "/" + destFontName);

            const fontFile = fs.createWriteStream(destFont);
            https.get(fontUrl, options, function (response) {
                response.pipe(fontFile);
            });
            css = css.replace(fontUrl, destFontName);
        }
        fs.writeFileSync(destCss, css);
    });
}

const dest = "../MdcBlazor/wwwroot";

extractMaterialIconFonts("https://fonts.googleapis.com/css?family=Material+Icons|Material+Icons+Outlined|Material+Icons+Sharp|Material+Icons+Round|Material+Icons+Two+Tone", dest + "/material-icons", "material-icons.css");
extractRobotoFonts("https://fonts.googleapis.com/css?family=Roboto:300,400,500", dest + "/roboto", "roboto.css");

