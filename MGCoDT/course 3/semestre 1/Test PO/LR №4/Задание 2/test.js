describe("Parse numbers and letters", function() {

    it("Beep-Boop", function() {
        assert.equal(func("123456qwerty1212wer"), "qwertywer2221116543");
        assert.equal(func("22113"), "31122");
        assert.equal(func("dsfjsdkl"), "dsfjsdkl0")
        assert.equal(func(""), "Error!")
    });  
});