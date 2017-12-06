//11.27 insertion sort
function insertionSort(arr){
    for(i=0; i< arr.length; i++){
        let temp = arr[i];
        let x = i-1;
        while(x>= 0 && arr[x]> temp){
            arr[x+1] = arr[x];
            x--;
        }
        arr[x+1] = temp;
    }
    return arr;
}

var array = [10,9,-1,77,13,18,33,1,3,-1.2];
// console.log(array)
// console.log(insertionSort(array));

//11.28
function partition(arr){
    let left = [];
    let right = [];
    
    for (let i=1; i<arr.length; i++){
        if(arr[i]< arr[0]){
            left.push(arr[i]);
        } else {
            right.push(arr[i]);
        }
    }

    return {"left": left, "right": right};
}

function mergeSortedArrays(left, right){
    let arr = [];
    let curPos = {
        left: 0,
        right: 0
    }

    while(curPos.left < left.length || curPos.right < right.length){
        if(typeof left[curPos.left]==='undefined'){
            arr.push(right[curPos.right++]);
        } else if(left[curPos.left] > right[curPos.right]){
            arr.push(right[curPos.right++]);
        } else {
            arr.push(left[curPos.left++]);
        }
    }
    return arr;
}
// console.log(partition(array));
// console.log(mergeSortedArrays([-1,1,3,5,7], [2,4,6,8]));

//11.30 
function mergeSort(arr){
    if(arr.length <= 1){
        return arr;
    }
    let left = [];
    let right = [];
    for(let i=0; i<arr.length; i++){
        if(i < arr.length/2){
            left.push(arr[i]);
        } else {
            right.push(arr[i]);
        }
    }
    return mergeSortedArrays(mergeSort(left), mergeSort(right));
}

function Heap() {
    let arr = [];
    arr.push(null)
}

Heap.prototype.add = function(val) {
    this.arr.push(val);
    let i = this.arr.length - 1;
    let k = math.floor(i / 2);
    while (arr[k] > val) {
        temp = this.arr[k];
        this.arr[k] = this.arr[i];
        this.arr[i] = temp;
        i = k;
        k = math.floor(i / 2);
    }
    return this;
}
Heap.prototype.extract = function() {
    let temp = this.arr[i];
    this.arr[1] = this.arr[this.arr.length];
    this.arr[this.arr.length - 1] = temp;
    let i = 1;
    let k = 2;
    while (this.arr[k] < this.arr[i]) {
        let temp1 = this.arr[i];
        this.arr[i] = this.arr[k];
        this.arr[k] = temp1;
        i = k;
        k = 2 * k;
    }
    return this.arr.pop();
}

let h1 = new Heap();

h1.add(4).add(2).add(6).add(99).add(2).add(1).add(29).add(17).add(22).add(3)

console.log(h1);