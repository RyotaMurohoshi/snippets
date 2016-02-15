/// <reference path="../typings/tsd.d.ts" />

'use strict';

import Promise = require('bluebird');
import fs = require('fs');

Promise.promisify(fs.readFile)('res/hello.txt').then(it => console.log(it.toString()));
