class SliderNth {
    constructor() {
        this.slider = document.querySelector('.nth-item-slider');
        this.slides = document.querySelectorAll('.slider-slide');
        this.sliderContainer = document.querySelector('.nth-item-slider-wrapper');
        this.controls = this.slider.querySelector('.nth-slides-control-wrapper');
        this.resolutionSettings = [{
            width: 425,
            num: 1
        },
        {
            width: 1240,
            num: 3
        },
        {
            width: 1440,
            num: 4
        },
        {
            width: 1980,
            num: 5
        }
        ]
    }

    init() {
        this.slides.forEach((item, i) => {
            this.createControl(i)
            this.activeSlide.classList.add('active-point');
        });

        this.width = this.slider.offsetWidth;
        this.setSlideWidth();

        window.addEventListener('resize', () => {
            this.width = this.slider.offsetWidth;
            this.setSlideWidth();
        });
        this.unwind()
    }

    unwind() {
        this.intervalSlide = setTimeout(this.changeSlide.bind(this), 2000);
    }
    createControl(id) {
        let cnt = document.createElement('span');
        cnt.dataset.id = id;
        if (id === 0) this.activeSlide = cnt;
        cnt.addEventListener('click', this.changeSlide.bind(this))
        this.controls.append(cnt);
    }
    changeSlide() {

        clearTimeout(this.intervalSlide);
        this.activeSlide.classList.remove('active-point');
        this.sliderContainer.style.transitionDuration = '0.2s'
        if (event) {

            this.activeSlide = event.target;
            this.sliderContainer.style.transform = `translateX(${(-this.activeSlide.dataset['id'] - 1) * this.translateSlide}px)`;
        } else if (this.controls.children[parseInt(this.activeSlide.dataset['id']) + 1]) {

            this.activeSlide = this.controls.children[parseInt(this.activeSlide.dataset['id']) + 1];
            this.sliderContainer.style.transform = `translateX(${(-this.activeSlide.dataset['id'] - 1) * this.translateSlide}px)`;
        } else {
            console.log('Обнулился');
            this.sliderContainer.style.transitionDuration = '0s'
            this.sliderContainer.style.transform = 'translateX(0px)'
            this.activeSlide = this.controls.children[0];
            //this.sliderContainer.style.transitionDuration = '0.2s'
            this.sliderContainer.style.transform = `translateX(${(-this.activeSlide.dataset['id'] - 1) * this.translateSlide}px)`;

        }

        this.activeSlide.classList.add('active-point');
        this.unwind();
        // this.sliderContainer.style.transitionDuration = '0.2s'
    }
    setSlideWidth() {
        if (this.currentSettings) {

            for (let i = 0; i < this.num - 1; i++) {
                this.sliderContainer.removeChild(this.sliderContainer.lastElementChild);
            }
            this.sliderContainer.removeChild(this.sliderContainer.firstElementChild);

        }
        this.currentSettings = this.resolutionSettings.find(item => this.width <= item.width);



        if (this.currentSettings?.width == 425) {
            this.num = this.currentSettings.num;
            this.slides.forEach(item => {
                item.style.marginLeft = '0px';
                item.style.minWidth = this.width + 'px';
                this.translateSlide = this.width;
            });

        } else {
            this.num = this.currentSettings.num;
            for (let i = 0; i < this.num - 1; i++) {
                let cln_first = this.slides[i].cloneNode(true)
                this.sliderContainer.append(cln_first)
            }
            let cln_last = this.slides[this.slides.length - 1].cloneNode(true)
            this.sliderContainer.prepend(cln_last)

            this.slides = [...this.sliderContainer.children];
            this.slides.forEach((item, i) => {
                item.style.marginLeft = i != 0 ? '10px' : '0px';
                item.style.minWidth = (this.width - 10 * this.num - 1) / this.num + 'px';
                this.translateSlide = (this.width - 10 * this.num - 1) / this.num + 10;
            });

        }
    }
    sliDeToInitPosition() {
        this.sliderContainer
    }
}

document.addEventListener('DOMContentLoaded', () => {
    if (!document.querySelector('.nth-item-slider')) return;
    let sliderBox = new SliderNth();
    sliderBox.init();
})