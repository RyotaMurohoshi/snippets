namespace list_example
open System
open NUnit.Framework

[<TestFixture>]
type Test() =

    let double n = n * 2
    let isEven n = n % 2 = 0
    let isZero n = n = 0
    let divideWith n = if n = 0 then None else Some(1.0 / float(n))

    [<Test>]
    member x.TestMap() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.map double, [2; 4; 6; 8; 10])

    [<Test>]
    member x.TestFilter() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.filter isEven, [2; 4])


    [<Test>]
    member x.TestForAll() =
        Assert.IsFalse([1; 2; 3; 4; 5] |> List.forall isEven)
        Assert.IsTrue([1; 2; 3; 4; 5] |> List.map double |> List.forall isEven)

    [<Test>]
    member x.TestExists() =
        Assert.IsTrue([1; 2; 3; 4; 5] |> List.exists isEven)
        Assert.IsFalse([1; 2; 3; 4; 5] |> List.exists isZero)

    [<Test>]
    member x.TestFind() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.find isEven, 2)

    [<Test>]
    member x.TestFindIndex() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findIndex isEven, 1)

    [<Test>]
    [<ExpectedException(typeof<Collections.Generic.KeyNotFoundException>)>]
    member x.TestFindIndex_Exception() =
        [1; 2; 3; 4; 5] |> List.findIndex isZero

    [<Test>]
    [<ExpectedException(typeof<Collections.Generic.KeyNotFoundException>)>]
    member x.TestFind_Exception() =
        [1; 2; 3; 4; 5] |> List.find isZero

    [<Test>]
    member x.TestFindBack() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findBack isEven, 4)

    [<Test>]
    [<ExpectedException(typeof<Collections.Generic.KeyNotFoundException>)>]
    member x.TestFindLast_Exception() =
        [1; 2; 3; 4; 5] |> List.findBack isZero

    [<Test>]
    member x.TestFindIndexBack() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findIndexBack isEven, 3)

    [<Test>]
    [<ExpectedException(typeof<Collections.Generic.KeyNotFoundException>)>]
    member x.TestFindIndexBack_Exception() =
        [1; 2; 3; 4; 5] |> List.findIndexBack isZero

    [<Test>]
    member x.TestTryFind() =
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFind isEven, Some(2))
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFind isZero, None)

    [<Test>]
    member x.TestTryFindBack() =
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindBack isEven, Some(4))
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindBack isZero, None)

    [<Test>]
    member x.TestTryFindIndex() =
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindIndex isEven, Some(1))
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindIndex isZero, None)

    [<Test>]
    member x.TestTryFindIndexBack() =
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindIndexBack isEven, Some(3))
         Assert.AreEqual([1; 2; 3; 4; 5] |> List.tryFindIndexBack isZero, None)

    [<Test>]
    member x.TestZip() =
         Assert.AreEqual(List.zip [1; 2; 3] ["a"; "b"; "c"], [(1,"a"); (2,"b"); (3,"c")])

    [<Test>]
    [<ExpectedException(typeof<System.ArgumentException>)>]
    member x.TestZip_Exception() =
         List.zip [1; 2; 3] [1;1;1;1;1;1]

    [<Test>]
    member x.TestZip3() =
         Assert.AreEqual(List.zip3 [1; 2; 3] ["a"; "b"; "c"] [3.0; 1.0; 4.0], [(1,"a", 3.0); (2,"b", 1.0); (3,"c", 4.0)])

    [<Test>]
    [<ExpectedException(typeof<System.ArgumentException>)>]
    member x.TestZip3_Exception() =
        List.zip3 [1; 2; 3; 4] ["a"; "b"] [3.0; 1.0; 4.0]

    [<Test>]
    member x.TestUnzip() =
         let listA, listB = List.unzip [(1,"a"); (2,"b"); (3,"c")]
         Assert.AreEqual(listA, [1; 2; 3])
         Assert.AreEqual(listB, ["a"; "b"; "c"])

    [<Test>]
    member x.TestUnzip3() =
         let listA, listB, listC = List.unzip3 [(1,"a", 3.0); (2,"b", 1.0); (3, "c", 4.0)]
         Assert.AreEqual(listA, [1; 2; 3])
         Assert.AreEqual(listB, ["a"; "b"; "c"])
         Assert.AreEqual(listC, [3.0; 1.0; 4.0])

    [<Test>]
    member x.TestEmpty() =
         let list = List.empty;
         Assert.AreEqual(list, [])
         Assert.IsTrue(list |> List.isEmpty)

    [<Test>]
    member x.TestHead() =
         Assert.AreEqual([1; 2; 3] |> List.head, 1)
         Assert.AreEqual([1] |> List.head, 1)

    [<Test>]
    [<ExpectedException(typeof<System.ArgumentException>)>]
    member x.Head_Exception() =
         [] |> List.head

    [<Test>]
    member x.TestTryHead() =
         Assert.AreEqual([1; 2; 3] |> List.tryHead, Some(1))
         Assert.AreEqual([1] |> List.tryHead, Some(1))
         Assert.AreEqual([] |> List.tryHead, None)

    [<Test>]
    member x.TestTail() =
         Assert.AreEqual([1; 2; 3] |> List.tail, [2; 3])
         Assert.AreEqual([1; 2] |> List.tail, [2])

         let emptyList : int list = []
         Assert.AreEqual([1] |> List.tail, emptyList);

    [<Test>]
    [<ExpectedException(typeof<System.ArgumentException>)>]
    member x.TestTail_Exception() =
         [] |> List.tail

    [<Test>]
    member x.TestChoose() =
        Assert.AreEqual([-2; -1; 0; 1; 2] |> List.choose divideWith, [-0.5; -1.0; 1.0; 0.5])

    [<Test>]
    member x.TestChunkSize() =
        Assert.AreEqual([-2; -1; 0; 1; 2] |> List.chunkBySize 2, [[-2; -1]; [0; 1]; [2]])
        Assert.AreEqual([-2; -1; 0; 1] |> List.chunkBySize 2, [[-2; -1]; [0; 1]])
        Assert.AreEqual([-2; -1] |> List.chunkBySize 2, [[-2; -1]])
        Assert.AreEqual([-2] |> List.chunkBySize 2, [[-2]])

    [<Test>]
    member x.TestContains() =
        Assert.IsTrue([-2; -1; 0; 1; 2] |> List.contains 0);
        Assert.IsFalse([-2; -1; 0; 1; 2] |> List.contains 3);
        Assert.IsFalse([] |> List.contains 2);

    [<Test>]
    member x.TestCollect() =
        let nTimesReplicateN = fun n -> List.replicate n n
        Assert.AreEqual([1; 2; 3] |> List.collect nTimesReplicateN, [1; 2; 2; 3; 3; 3]);
        let returnEmptyList = fun n -> []
        Assert.AreEqual([1; 2; 3] |> List.collect returnEmptyList, []);

    [<Test>]
    member x.TestDistinct() =
        Assert.AreEqual([1; 2; 3] |> List.distinct, [1; 2; 3]);
        Assert.AreEqual([1; 2; 3; 2; 1] |> List.distinct, [1; 2; 3]);
        Assert.AreEqual([2; 2; 3; 3; 3; 1;] |> List.distinct, [2; 3; 1]);
        Assert.AreEqual([1; 1; 1; 1] |> List.distinct, [1]);
        Assert.AreEqual([] |> List.distinct, []);

    [<Test>]
    member x.TestConcat() =
        Assert.AreEqual(List.concat [[1; 2; 3] ; [4; 5; 6]], [1; 2; 3; 4; 5; 6]);
        Assert.AreEqual(List.concat [[1; 2]; [3 ; 4]; [5; 6]], [1; 2; 3; 4; 5; 6]);
        Assert.AreEqual(List.concat [[1]; [2; 3];  [4; 5; 6]], [1; 2; 3; 4; 5; 6]);
        Assert.AreEqual(List.concat [[]; [1]; [2; 3];  [4; 5; 6]], [1; 2; 3; 4; 5; 6]);
        Assert.AreEqual(List.concat [[]], []);
        Assert.AreEqual(List.concat [], []);