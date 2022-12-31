var List = function (start, end, _step = 1) {
    var numbers = [];
    var step = _step;

    var fillList = (function () {
        for (var current = start; current <= end; current += step) {
            numbers.push(current);
        }
    })();

    Object.defineProperty(this, "append", {
        value: function (newValue) {
            if (
                numbers.length === 0 ||
                numbers[numbers.length - 1] === newValue - step
            )
                numbers.push(newValue);
            else throw new RangeError(`${newValue} is not in sequence`);
        },
    });

    Object.defineProperty(this, "prepend", {
        value: function (newValue) {
            if (numbers.length === 0 || numbers[0] === newValue + step)
                numbers.unshift(newValue);
            else throw new RangeError(`${newValue} is not in sequence`);
        },
    });

    Object.defineProperty(this, "pop", {
        value: function () {
            if (numbers.length !== 0) numbers.pop();
            else throw new Error("List is already empty");
        },
    });

    Object.defineProperty(this, "dequeue", {
        value: function () {
            if (numbers.length !== 0) numbers.shift();
            else throw new Error("List is already empty");
        },
    });

    Object.defineProperty(this, "toString", {
        value: function () {
            var str = "[ ";
            for (var i = 0; i < numbers.length; i++) str += `${numbers[i]} `;
            str += "]";
            return str;
        },
    });
};

var newList = new List(5, 15, 5);
console.log(newList.toString());

newList.append(20);
console.log(newList.toString());

newList.prepend(0);
console.log(newList.toString());

newList.pop();
console.log(newList.toString());

newList.dequeue();
console.log(newList.toString());
