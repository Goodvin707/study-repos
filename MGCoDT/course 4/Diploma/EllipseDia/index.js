const path = require('path');
const express = require('express');
const session = require('express-session');
const routes = require('./router');

const app = express();
app.set("view engine", "ejs");

app.use(session({
    secret: 'secret',
    resave: true,
    saveUninitialized: true
}));

app.use(express.static(path.join(__dirname)));

app.use(express.urlencoded({ extended: false, limit: '50mb' }));

routes(app);

app.listen(3333, () => {
    console.log('Application listening on port 3333');
});