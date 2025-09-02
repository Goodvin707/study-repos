function onInit(editor) {
    mxVertexHandler.prototype.rotationEnabled = true;
    mxGraphHandler.prototype.guidesEnabled = true;
    mxGuide.prototype.isEnabledForEvent = function (evt) {
        return !mxEvent.isAltDown(evt);
    };

    mxEdgeHandler.prototype.snapToTerminals = true;
    mxConnectionHandler.prototype.connectImage = new mxImage('images/connector.gif', 16, 16);
    editor.graph.setConnectable(true);

    // Копирует фигуру, если стрелка не была присоединена к другой фигуре
    editor.graph.connectionHandler.setCreateTarget(true);

    editor.urlImage = '/diagrameditor';

    // Обновление названия документа
    var title = document.getElementById('title');

    if (title != null) {
        var f = function (sender) {
            title.innerHTML = sender.getTitle();
        };

        editor.addListener(mxEvent.ROOT, f);
        f(editor);
    }

    // Изменение масштаба на колесо мышы
    mxEvent.addMouseWheelListener(function (evt, up) {
        if (!mxEvent.isConsumed(evt)) {
            if (up) {
                editor.execute('zoomIn');
            }
            else {
                editor.execute('zoomOut');
            }

            mxEvent.consume(evt);
        }
    });

    // Логика переключения между XML и графическим отображением
    var textNode = document.getElementById('xml');
    var graphNode = editor.graph.container;
    var sourceInput = document.getElementById('source');
    sourceInput.checked = false;

    var graphAndXMLConnecting = function (editor) {
        if (sourceInput.checked) {
            graphNode.style.display = 'none';
            textNode.style.display = 'inline';

            var enc = new mxCodec();
            var node = enc.encode(editor.graph.getModel());

            textNode.value = mxUtils.getPrettyXml(node);
            textNode.originalValue = textNode.value;
            textNode.focus();
        }
        else {
            graphNode.style.display = '';

            if (textNode.value != textNode.originalValue) {
                var doc = mxUtils.parseXml(textNode.value);
                var dec = new mxCodec(doc);
                dec.decode(doc.documentElement, editor.graph.getModel());
            }

            textNode.originalValue = null;

            if (mxClient.IS_IE) {
                mxUtils.clearSelection();
            }

            textNode.style.display = 'none';
            editor.graph.container.focus();
        }
    };

    editor.addAction('switchView', graphAndXMLConnecting);

    mxEvent.addListener(sourceInput, 'click', function () {
        editor.execute('switchView');
    });


    // Логика отображения окна с подбором цвета
    var colorDialog = document.getElementById('colorDialog');
    var colorInput = document.getElementById('color');
    colorInput.checked = false;

    var switchColorPicker = function (editor) {
        if (colorInput.checked) {
            colorDialog.style.display = 'inline-block';
            colorPickerInit();
        }
        else {
            colorDialog.style.display = 'none';
        }
    };

    editor.addAction('switchColor', switchColorPicker);

    mxEvent.addListener(colorInput, 'click', function () {
        editor.execute('switchColor');
    });

    mxEvent.addListener(document.getElementById('graph'), 'dragover', function (evt) {
        if (editor.graph.isEnabled()) {
            evt.stopPropagation();
            evt.preventDefault();
        }
    });

    mxEvent.addListener(document.getElementById('graph'), 'drop', function (evt) {
        if (editor.graph.isEnabled()) {
            evt.stopPropagation();
            evt.preventDefault();

            // Gets drop location point for vertex
            var pt = mxUtils.convertPoint(editor.graph.container, mxEvent.getClientX(evt), mxEvent.getClientY(evt));
            var tr = editor.graph.view.translate;
            var scale = editor.graph.view.scale;
            var x = pt.x / scale - tr.x;
            var y = pt.y / scale - tr.y;

            // Converts local images to data urls
            var filesArray = event.dataTransfer.files;

            for (var i = 0; i < filesArray.length; i++) {
                handleDrop(editor, filesArray[i], x + i * 10, y + i * 10);
            }
        }
    });

    let graphCodedInXML = document.getElementById('diagramMarkdown');
    let username = (document.getElementById('username').innerHTML).trim();
    if (graphCodedInXML && !username) {
        alert('Неавторизованные пользователи не могут просматривать диаграммы других пользователей');
    }
    if (graphCodedInXML && username) {
        var doc = mxUtils.parseXml(graphCodedInXML.value);
        var dec = new mxCodec(doc);
        dec.decode(doc.documentElement, editor.graph.getModel());
    }

    var node = document.getElementById('mainActions');
    var buttons = ['group', 'ungroup', 'cut', 'copy', 'paste', 'delete', 'undo', 'redo', 'show'];

    if (editor.urlImage != null) {

        var posterPrint = function (editor) {
            let pageCount = mxUtils.prompt("Введите максимальное число страниц", "1");

            if (pageCount != null) {
                let scale = mxUtils.getScaleForPageCount(pageCount, editor.graph);
                let preview = new mxPrintPreview(editor.graph, scale);
                preview.open();
            }
        };

        var saveXML = function (editor) {
            let encoder = new mxCodec();
            let xml = mxUtils.getPrettyXml(encoder.encode(editor.graph.getModel()));
            let filename = title.innerHTML;
            if (username) {
                new mxXmlRequest(editor.urlImage,
                    'filename=' + filename +
                    '&format=xml' +
                    '&username=' + username +
                    '&xml=' + encodeURIComponent(xml)).simulate(document, '_blank');
            }
            else {
                alert('Чтобы сохранить диаграмму нужно авторизоваться');
            }
        };

        var exportXML = function (editor) {
            var encoder = new mxCodec();
            var xml = mxUtils.getPrettyXml(encoder.encode(editor.graph.getModel()));

            const downLink = document.createElement('a');
            downLink.download = title.innerHTML + '.xml';
            const blob = new Blob([xml]);
            downLink.href = URL.createObjectURL(blob);
            document.body.appendChild(downLink);
            downLink.click();
            document.body.removeChild(downLink);
        };

        var exportSvgPng = function (editor) {
            document.getElementsByTagName('span')[7].click(); // задание масштаба по размеру окна редактора

            var graph = editor.graph;
            var scale = graph.view.scale;
            var bounds = graph.getGraphBounds();

            var svgDoc = mxUtils.createXmlDocument();
            var root = (svgDoc.createElementNS != null) ?
                svgDoc.createElementNS(mxConstants.NS_SVG, 'svg') : svgDoc.createElement('svg');

            if (root.style != null) {
                root.style.backgroundColor = '#FFFFFF';
            }
            else {
                root.setAttribute('style', 'background-color:#FFFFFF');
            }

            if (svgDoc.createElementNS == null) {
                root.setAttribute('xmlns', mxConstants.NS_SVG);
            }

            root.setAttribute('width', Math.ceil(bounds.width * scale + 2) + 'px');
            root.setAttribute('height', Math.ceil(bounds.height * scale + 2) + 'px');
            root.setAttribute('xmlns:xlink', mxConstants.NS_XLINK);
            root.setAttribute('version', '1.1');

            var group = (svgDoc.createElementNS != null) ?
                svgDoc.createElementNS(mxConstants.NS_SVG, 'g') : svgDoc.createElement('g');
            group.setAttribute('transform', 'translate(0.5,0.5)');
            root.appendChild(group);
            svgDoc.appendChild(root);

            var svgCanvas = new mxSvgCanvas2D(group);
            svgCanvas.translate(Math.floor(1 / scale - bounds.x), Math.floor(1 / scale - bounds.y));
            svgCanvas.scale(scale);

            var imgExport = new mxImageExport();
            imgExport.drawState(graph.getView().getState(graph.model.root), svgCanvas);

            var name = title.innerHTML;
            var xml = encodeURIComponent(mxUtils.getXml(root));

            new mxXmlRequest(editor.urlImage,
                'filename=' + name +
                '&format=svg' +
                '&xml=' + xml).simulate(document, "_blank");
        };

        editor.addAction('posterPrint', posterPrint);
        editor.addAction('saveXML', saveXML);
        editor.addAction('exportXML', exportXML);
        editor.addAction('exportSvgPng', exportSvgPng);

        buttons.push('posterPrint');
        buttons.push('saveXML');
        buttons.push('exportXML');
        buttons.push('exportSvgPng');
    };

    for (var i = 0; i < buttons.length; i++) {
        var button = document.createElement('button');
        mxUtils.write(button, mxResources.get(buttons[i]));

        var factory = function (name) {
            return function () {
                editor.execute(name);
            };
        };

        mxEvent.addListener(button, 'click', factory(buttons[i]));
        node.appendChild(button);
    }

    // Создание кнопок выделения
    var node = document.getElementById('selectActions');
    mxUtils.write(node, 'Выделить: ');
    mxUtils.linkAction(node, 'Всё', editor, 'selectAll');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Ничего', editor, 'selectNone');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Блоки', editor, 'selectVertices');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Соединения', editor, 'selectEdges');

    // Создание кнопок масштабирования
    var node = document.getElementById('zoomActions');
    mxUtils.write(node, 'Масштабирование: ');
    mxUtils.linkAction(node, 'Ближе', editor, 'zoomIn');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Дальше', editor, 'zoomOut');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Действительное (1:1)', editor, 'actualSize');
    // mxUtils.write(node, ', ');
    mxUtils.linkAction(node, 'Подгонка по размеру', editor, 'fit');
}

// Handles each file as a separate insert for simplicity.
// Use barrier to handle multiple files as a single insert.
function handleDrop(editor, file, x, y) {
    if (file.type.substring(0, 5) == 'image') {
        var reader = new FileReader();

        reader.onload = function (e) {
            // Gets size of image for vertex
            var data = e.target.result;

            var img = new Image();

            img.onload = function () {
                var w = Math.max(1, img.width);
                var h = Math.max(1, img.height);

                // Converts format of data url to cell style value for use in vertex
                var semi = data.indexOf(';');

                if (semi > 0) {
                    data = data.substring(0, semi) + data.substring(data.indexOf(',', semi + 1));
                }

                editor.graph.insertVertex(null, null, '', x, y, w, h, 'shape=image;image=' + data + ';');
            };

            img.src = data;
        }
    };

    reader.readAsDataURL(file);
};

window.onbeforeunload = function () { return mxResources.get('changesLost'); };