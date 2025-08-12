describe("MultiplicityFive", function() {
    it("Find miltipliced numbers", function() {
        assert.equal(multiplicityFive([1, 5, 10, 15, 25, 2, 3, 4]), "5, 10, 15, 25");
        assert.equal(multiplicityFive([1, 5, 10, 15, 25, 50, 55, 555]), "5, 10, 15, 25, 50, 55, 555")
        assert.equal(multiplicityFive([1, 5, 10, 15, 25, 45, 55, 255]), "5, 10, 15, 25, 45, 55, 255")
        assert.equal(multiplicityFive([1, 5, 10, 15, 25, 35, 55, 65]), "5, 10, 15, 25, 35, 55, 65")
    });
});