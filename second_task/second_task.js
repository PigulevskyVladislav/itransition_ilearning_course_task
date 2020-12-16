const dir = process.cwd();
const sha3 = require('./sha3.js'); //external lib
const fs = require('fs');

fs.readdir(process.cwd(), (err, files) => {
  files.forEach(file => {
  	readFile(file);
  });
});

function readFile(file) {
  fs.readFile(file, 'utf8', (err,data) =>
    console.log(`${file} ${sha3.sha3_256(data)}`)
  );
}