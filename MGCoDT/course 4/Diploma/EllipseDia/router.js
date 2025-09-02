// const express = require("express");
// const urlencodedParser = express.urlencoded({ extended: false });
// const jsonParser = express.json();
// const path = require('path');
const fs = require('fs')
const connection = require('./database');
const querystring = require('querystring');

const router = (app) => {
    app.get('/', (req, res) => {
        res.sendFile(`${__dirname}/html-pages/main-page.html`);
    });

    app.get('/auth-or-reg', (req, res) => {
        req.session.loggedin = false;
        req.session.username = '';
        req.session.email = '';
        res.sendFile(`${__dirname}/html-pages/auth-and-reg.html`);
    });

    app.post('/registrated', (req, res) => {
        connection.query("SELECT * FROM users where nickname=?", [req.body.username], function (err, results) {
            if (results.length == 0) {
                connection.query('INSERT INTO users(nickname, pasword, email) VALUES(?, ?, ?)', [req.body.username, req.body.password, req.body.email], function (err, results) {
                    if (err) console.log(err);
                    else {
                        req.session.loggedin = true;
                        req.session.username = req.body.username;
                        req.session.email = req.body.email;

                        res.redirect('/account');
                    };
                });
            }
            else {
                res.redirect('/auth-or-reg');
            }
        });
    });

    app.post('/authorized', (req, res) => {
        connection.query("SELECT * FROM users where nickname=? and pasword=?", [req.body.username, req.body.password], function (err, results) {
            if (results.length == 0) {
                res.redirect('/auth-or-reg');
            }
            else {
                req.session.loggedin = true;
                req.session.username = results[0].nickname;
                req.session.email = results[0].email;

                res.redirect('/account');
            }
        });
    });

    app.post('/updated', (req, res) => {
        // Изменение аккаунта
        connection.query('UPDATE users SET nickname=?, pasword=?, email=? WHERE nickname=?', [req.body.username, req.body.password, req.body.email, req.session.username], function (err, results) {
            req.session.loggedin = true;
            req.session.username = req.body.username;
            req.session.email = req.body.email;
            res.redirect('/account');
        });
    });

    app.get('/account', (req, res) => {
        if (req.session.loggedin) {
            // Получить с БД пути файлов авторизованного пользователя

            const sql = "select id from users where nickname=?";
            connection.query(sql, [req.session.username], function (err, results) {

                const queryParams = [results[0].id];
                const sql = "select diag_path from user_diagrams Join users ON user_diagrams.id_users=users.id Join diagrams ON user_diagrams.id_diagrams=diagrams.id where users.id=?";
                connection.query(sql, queryParams, function (err, results) {
                    res.render('account', {
                        id: String(queryParams[0]),
                        username: req.session.username,
                        email: req.session.email,
                        diagList: results
                    });
                });
            });
        } else {
            res.redirect('/auth-or-reg');
        }
    });

    app.get('/diagrameditor', (req, res) => {
        let filename = querystring.parse(req.url)['/diagrameditor?filename'];
        if (filename) {
            fs.access(filename, fs.constants.F_OK, (err) => {
                if (err) {
                    console.log(`${filename}: ${err}`);
                    res.writeHead(404, { "Content-Type": "text/html" });
                    res.write(`No sush file or directory: '${filename}'`);
                    res.end();
                }
                else {
                    let fileContent = fs.readFileSync(filename, "utf8");

                    res.render('diagram-editor', {
                        username: req.session.username,
                        email: req.session.email,
                        diagramMarkdown: fileContent
                    });
                }
            });
        }
        else {
            res.render('diagram-editor', {
                username: req.session.username,
                email: req.session.email,
                diagramMarkdown: null
            });
        }
    });

    app.get('/help', (req, res) => {
        res.sendFile(`${__dirname}/html-pages/help-page.html`);
    });

    app.post("/diagrameditor", (req, res) => {
        if (req.body.format == 'xml') {

            const sql = "SELECT id FROM users where nickname=?";
            connection.query(sql, [req.session.username], function (err, results) {

                let diag_path = `diagrams/${results[0].id}-${req.body.filename}.xml`;
                fs.writeFile(diag_path, decodeURIComponent(req.body.xml), function (error) {
                    if (error) throw error;

                    // Проверка на новый файл или перезапись старого
                    connection.query(`SELECT diag_path FROM diagrams where diag_path='${diag_path}'`, function (err, results) {
                        if (results.length > 0) {
                            console.log('Файл \"' + diag_path + '\" был перезаписан');

                            let body = '<script>window.close();</script>';
                            res.writeHead(200, { "Content-Type": "text/html" });
                            res.write(body);
                            res.end();
                        }
                        else {
                            // Новый файл
                            const queryParams = [diag_path];
                            const sql = "INSERT INTO diagrams(diag_path) VALUES(?)";
                            connection.query(sql, queryParams, function (err, results) {
                                if (err) console.log(err);
                                else {
                                    let id_diagram = results.insertId;

                                    const queryParams = [req.body.username];
                                    const sql = "SELECT id FROM users where nickname=?";
                                    connection.query(sql, queryParams, function (err, results) {
                                        if (err) console.log(err);
                                        else {
                                            let id_user = results[0].id;
                                            const queryParams = [id_user, id_diagram];
                                            const sql = "INSERT INTO user_diagrams(id_users, id_diagrams) VALUES(?, ?)";
                                            connection.query(sql, queryParams, function (err, results) {
                                                if (err) console.log(err);
                                                else {
                                                    let body = '<script>window.close();</script>';
                                                    res.writeHead(200, { "Content-Type": "text/html" });
                                                    res.write(body);
                                                    res.end();
                                                }
                                            });
                                        }
                                    });
                                }
                            });
                        }
                    });
                });
            });
        }

        if (req.body.format == 'svg') {
            res.render('export-image', {
                diag_title: decodeURIComponent(req.body.filename),
                svgContent: decodeURIComponent(req.body.xml)
            });
        }
    });

    app.get("/fusion", (req, res) => {
        // Удаление диаграммы
        let filename = querystring.parse(req.url)['/fusion?filename'];

        if (filename) {
            fs.unlink(filename, (err) => {
                if (err) throw err;
            });

            const queryParams = [filename];
            const sql = "DELETE FROM diagrams where diag_path=?";
            connection.query(sql, queryParams, function (err, results) {
                if (err) console.log(err);
                else {
                    res.redirect('/account');
                }
            });
        }
        else {
            res.redirect('/account');
        }
    });

    app.post("/accfusion", (req, res) => {
        // Удаление аккаунта

        const queryParams = [req.session.username];
        console.log(queryParams);
        const sql = "SELECT id FROM users where nickname=?";
        connection.query(sql, queryParams, function (err, results) {
            if (err) console.log(err);
            else {
                console.log(results);
                let id_user = results[0].id;

                const queryParams = ['%/' + id_user + '-%'];
                const sql = "SELECT * FROM diagrams, user_diagrams where diagrams.id=user_diagrams.id_diagrams and diag_path like ?";
                connection.query(sql, queryParams, function (err, results) {
                    if (err) console.log(err);
                    else {

                        if (results.length > 0) {
                            for (let i = 0; i < results.length; i++) {
                                const diag_path = results[i]['diag_path'];
                                fs.unlink(diag_path, (err) => {
                                    if (err) console.log(err);
                                    console.log('Была удалена диаграмма: ' + diag_path);
                                });

                                const queryParams = [diag_path];
                                const sql = "DELETE FROM diagrams where diag_path=?";
                                connection.query(sql, queryParams, function (err, results) {
                                    if (err) console.log(err);
                                });
                            }
                        }
                    }
                });

                connection.query("DELETE FROM users where nickname=? and email=?", [req.session.username, req.session.email], function (err, results) {
                    if (err) console.log(err);
                    console.log('Был удален аккаунт');
                });

                req.session.loggedin = false;
                req.session.username = '';
                req.session.email = '';
                res.redirect('/');
            }
        });
    });
};

module.exports = router;