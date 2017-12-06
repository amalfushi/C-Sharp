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

// function Heap() {
//     var arr = [];
//     arr.push(null)
// }

// Heap.prototype.add = function(val) {
//     this.arr.push(val);  <---this fucker is broke
//     let i = this.arr.length - 1;
//     let k = math.floor(i / 2);
//     while (arr[k] > val) {
//         temp = this.arr[k];
//         this.arr[k] = this.arr[i];
//         this.arr[i] = temp;
//         i = k;
//         k = math.floor(i / 2);
//     }
//     return this;
// }
// Heap.prototype.extract = function() {
//     let temp = this.arr[i];
//     this.arr[1] = this.arr[this.arr.length];
//     this.arr[this.arr.length - 1] = temp;
//     let i = 1;
//     let k = 2;
//     while (this.arr[k] < this.arr[i]) {
//         let temp1 = this.arr[i];
//         this.arr[i] = this.arr[k];
//         this.arr[k] = temp1;
//         i = k;
//         k = 2 * k;
//     }
//     return this.arr.pop();
// }

class Node {
    constructor(val, priority){
        this.val = val;
        this.priority = priority;
    }
}
class PriorityQueue {
    constructor(){
        this.heap = [null]
    }
    
    insert(value, priority){
        const newNode = new Node(value, priority);
        this.heap.push(newNode);
        let currentNodeIdx = this.heap.length -1;
        let currentNodeParentIdx = Math.floor(currentNodeIdx/2);
        while (this.heap[currentNodeParentIdx] && newNode.priority < this.heap[currentNodeParentIdx].priority){// bubble up from the last value swapping with the parent if lower
            const parent = this.heap[currentNodeParentIdx]; //parent is previous node
            this.heap[currentNodeParentIdx] = newNode; //the node at the parent index is now the new node
            this.heap[currentNodeIdx] = parent; //the node at the current index is now the parent
            currentNodeIdx = currentNodeParentIdx; //current node index = parent node index
            currentNodeParentIdx = Math.floor(currentNodeIdx / 2); // parent node index is current index/2 rounded down
        }
        return this;
    }

    remove() {
        if (this.heap.length < 3) {
            const toReturn = this.heap.pop();
            this.heap[0]= null;
            return toReturn
        }
        
        const toRemove = this.heap[1];
        this.heap[1] = this.heap.pop();
        let currentIdx = 1;
        let [left, right] = [2*currentIdx, 2*currentIdx+1];
        let currentChildIdx = this.heap[right] && this.heap[right].priority <= this.heap[left].priority ? right : left;//if right exists and it's priority is lte 
        while(this.heap[currentChildIdx] && this.heap[currentIdx].priority >= this.heap[currentChildIdx].priority){
            let currentNode = this.heap[currentIdx];
            let currentChildNode = this.heap[currentChildIdx];
            this.heap[currentChildIdx] = currentNode;
            this.heap[currentIdx] = currentChildNode;
            console.log(this.heap)
        }
        return toRemove;
    }

    // 1,
    // 2,5
    // 8,3,7,10
    // 9,
    
    // 9,
    // 2,5,
    // 8,3,7,10,
    // 1,
    
    // 2,
    // 9 5
    // 8,3 7,10
    // remove(){
    //     if 
    // }
}

var pq = new PriorityQueue();
pq.insert("a", 5).insert("b", 8).insert("c", 1).insert("d", 3).insert("e", 2).insert("f", 7).insert("g", 10).insert("h", 9)
// console.log(pq)
console.log(pq.remove());