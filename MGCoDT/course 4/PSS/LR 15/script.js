const head = document.querySelector('head');
const headHtml = document.querySelector('html');
headHtml.setAttribute('lang', 'rus');
const headTitle = document.createElement('title');
headTitle.innerHTML = 'LR15';
head.appendChild(headTitle)
const styleHtml = document.createElement('style');

styleHtml.innerHTML = `
 * {
  font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
}

.grid-container {
  display: grid;
  grid-template-rows: 200px 500px;
  grid-template-columns: 1fr 1fr;
}

.headerTitle {
  display: flex;
  grid-column-start: 1;
  grid-column-end: 3;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.block {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 400px;
  text-align: center;
  border-radius: 5px;
}


.firstBlock {
  border: 1px solid gray;
  justify-self: flex-end;
}
.secondBlock {
  background-color: rgb(119, 18, 149);
  color: #FFFFFF;
}

.secondBlock .para{
  color: rgb(227, 219, 8);
}

.btn {
  background-color: transparent;
  width: 200px;
  height: 50px;
  border: 2px solid yellow;
  border-radius: 40px;
  letter-spacing: 1px;
}

.secondBlock>.btn{
  color: #FFFFFF;
}


.blockHeader {
  font-size: 40px;
}`;

head.appendChild(styleHtml)
const body = document.querySelector('body');
const container = document.createElement('div');
container.classList.add('grid-container');
body.appendChild(container)



const headerWrapper = document.createElement('div');
headerWrapper.classList.add('headerTitle')
const header = document.createElement('h1');
header.innerHTML = 'Choose Your Option';
const headerPar = document.createElement('p');
headerPar.innerHTML = 'But i must explain to you how all this mistaken idea of denouncing';
headerWrapper.appendChild(header);
headerWrapper.appendChild(headerPar)
container.appendChild(headerWrapper)


const firstBlock = document.createElement('div');
firstBlock.classList.add('firstBlock');
firstBlock.classList.add('block')
const firstBlockPar = document.createElement('p');
firstBlockPar.innerHTML = 'FREELANCER';
firstBlockPar.classList.add('para')
const firstBlockHeader = document.createElement('h2');
firstBlockHeader.innerHTML = 'Initially designed to';
firstBlockHeader.classList.add('blockHeader')

const firstBlockDescr = document.createElement('p');
firstBlockDescr.innerHTML = 'But i must explain to you how all this mistaken idea of denouncing';

const btnFirst = document.createElement('button');
btnFirst.classList.add('btn')
btnFirst.innerHTML = 'START HERE';

firstBlock.appendChild(firstBlockPar);
firstBlock.appendChild(firstBlockHeader);
firstBlock.appendChild(firstBlockDescr);
firstBlock.appendChild(btnFirst);
container.appendChild(firstBlock);

const secondBlock = document.createElement('div');
secondBlock.classList.add('secondBlock');
secondBlock.classList.add('block')
const secondBlockPar = document.createElement('p');
secondBlockPar.innerHTML = 'STUDIO';
secondBlockPar.classList.add('para')
const secondBlockHeader = document.createElement('h2');
secondBlockHeader.innerHTML = 'Initially designed to';
secondBlockHeader.classList.add('blockHeader')

const secondBlockDescr = document.createElement('p');
secondBlockDescr.innerHTML = 'But i must explain to you how all this mistaken idea of denouncing';

const btnSecond = document.createElement('button');
btnSecond.classList.add('btn');

btnSecond.innerHTML = 'START HERE';

secondBlock.appendChild(secondBlockPar);
secondBlock.appendChild(secondBlockHeader);
secondBlock.appendChild(secondBlockDescr);
secondBlock.appendChild(btnSecond);
container.appendChild(secondBlock);