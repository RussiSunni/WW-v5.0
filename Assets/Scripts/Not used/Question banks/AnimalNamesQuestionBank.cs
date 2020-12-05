using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimalNamesQuestionBank : Question
{
    public static List<Question> questions = new List<Question>();
    public static Question animalName001 = new Question();
    public static Question animalName002 = new Question();
    public static Question animalName003 = new Question();
    public static Question animalName004 = new Question();
    public static Question animalName005 = new Question();
    public static Question animalName006 = new Question();
    public static Question animalName007 = new Question();
    public static Question animalName008 = new Question();
    public static Question animalName009 = new Question();
    public static Question animalName010 = new Question();
    public static Question animalName011 = new Question();
    public static Question animalName012 = new Question();
    public static Question animalName013 = new Question();
    public static Question animalName014 = new Question();
    public static Question animalName015 = new Question();
    public static Question animalName016 = new Question();
    public static Question animalName017 = new Question();
    public static Question animalName018 = new Question();
    public static Question animalName019 = new Question();
    public static Question animalName020 = new Question();
    public static Question animalName021 = new Question();
    public static Question animalName022 = new Question();
    public static Question animalName023 = new Question();
    public static Question animalName024 = new Question();
    public static Question animalName025 = new Question();
    public static Question animalName026 = new Question();
    public static Question animalName027 = new Question();
    public static Question animalName028 = new Question();
    public static Question animalName029 = new Question();
    public static Question animalName030 = new Question();
    public static Question animalName031 = new Question();
    public static Question animalName032 = new Question();
    public static Question animalName033 = new Question();
    public static Question animalName034 = new Question();
    public static Question animalName035 = new Question();
    public static Question animalName036 = new Question();
    public static Question animalName037 = new Question();


    void Start()
    {
        animalName001 = new Question()
        {
            number = 1,
            questionName = "cat",
            sprite = Resources.Load<Sprite>("Questions/Animals/Cat"),
            answerOptions = new List<string>()
        {
            "bear",
            "dog",
            "cat",
            "horse"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Cat",
            position = new Vector3(-1.7f, 1.6f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName002 = new Question()
        {
            number = 2,
            questionName = "dog",
            sprite = Resources.Load<Sprite>("Questions/Animals/Dog"),
            answerOptions = new List<string>()
        {
            "mouse",
            "cat",
            "duck",
            "dog"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Dog",
            position = new Vector3(-1.25f, 1.3f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName003 = new Question()
        {
            number = 3,
            questionName = "horse",
            sprite = Resources.Load<Sprite>("Questions/Animals/Horse"),
            answerOptions = new List<string>()
        {
            "dog",
            "horse",
            "mouse",
            "ant"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Horse",
            position = new Vector3(-1f, 1.7f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName004 = new Question()
        {
            number = 4,
            questionName = "bear",
            sprite = Resources.Load<Sprite>("Questions/Animals/Bear"),
            answerOptions = new List<string>()
        {
            "bear",
            "horse",
            "mouse",
            "ant"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Bear",
            position = new Vector3(-0.8f, 1.6f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName005 = new Question()
        {
            number = 5,
            questionName = "wolf",
            sprite = Resources.Load<Sprite>("Questions/Animals/Wolf"),
            answerOptions = new List<string>()
        {
            "cat",
            "wolf",
            "mouse",
            "ant"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Wolf",
            position = new Vector3(-1.5f, 1.9f, 0f),
            scale = new Vector3(0.7f, 0.7f, 1.0f)
        };

        animalName006 = new Question()
        {
            number = 6,
            questionName = "zebra",
            sprite = Resources.Load<Sprite>("Questions/Animals/Zebra"),
            answerOptions = new List<string>()
        {
            "dog",
            "horse",
            "mouse",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Zebra",
            position = new Vector3(-0.8f, 1.65f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName007 = new Question()
        {
            number = 7,
            questionName = "owl",
            sprite = Resources.Load<Sprite>("Questions/Animals/Owl"),
            answerOptions = new List<string>()
        {
            "dog",
            "horse",
            "owl",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Owl"
        };

        animalName008 = new Question()
        {
            number = 8,
            questionName = "monkey",
            sprite = Resources.Load<Sprite>("Questions/Animals/Monkey"),
            answerOptions = new List<string>()
        {
            "monkey",
            "horse",
            "owl",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Monkey"
        };

        animalName009 = new Question()
        {
            number = 9,
            questionName = "parrot",
            sprite = Resources.Load<Sprite>("Questions/Animals/Parrot"),
            answerOptions = new List<string>()
        {
            "monkey",
            "parrot",
            "owl",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Parrot"
        };

        animalName010 = new Question()
        {
            number = 10,
            questionName = "giraffe",
            sprite = Resources.Load<Sprite>("Questions/Animals/Giraffe"),
            answerOptions = new List<string>()
        {
            "giraffe",
            "parrot",
            "owl",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Giraffe"
        };

        animalName011 = new Question()
        {
            number = 11,
            questionName = "lion",
            sprite = Resources.Load<Sprite>("Questions/Animals/Lion"),
            answerOptions = new List<string>()
        {
            "giraffe",
            "parrot",
            "lion",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Lion"
        };

        animalName012 = new Question()
        {
            number = 12,
            questionName = "crocodile",
            sprite = Resources.Load<Sprite>("Questions/Animals/Crocodile"),
            answerOptions = new List<string>()
        {
            "crocodile",
            "parrot",
            "lion",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Crocodile"
        };

        animalName013 = new Question()
        {
            number = 13,
            questionName = "cow",
            sprite = Resources.Load<Sprite>("Questions/Animals/Cow"),
            answerOptions = new List<string>()
        {
            "cow",
            "parrot",
            "lion",
            "zebra"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Cow"
        };

        animalName014 = new Question()
        {
            number = 14,
            questionName = "duck",
            sprite = Resources.Load<Sprite>("Questions/Animals/Duck"),
            answerOptions = new List<string>()
        {
            "cow",
            "parrot",
            "lion",
            "duck"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Duck",
            position = new Vector3(-1.6f, 1.2f, 0f),
            scale = new Vector3(0.6f, 0.6f, 1.0f)
        };

        animalName015 = new Question()
        {
            number = 15,
            questionName = "pig",
            sprite = Resources.Load<Sprite>("Questions/Animals/Pig"),
            answerOptions = new List<string>()
        {
            "cow",
            "parrot",
            "pig",
            "duck"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Pig",
            position = new Vector3(-1.25f, 1.35f, 0f),
            scale = new Vector3(0.8f, 0.8f, 1.0f)
        };

        animalName016 = new Question()
        {
            number = 16,
            questionName = "donkey",
            sprite = Resources.Load<Sprite>("Questions/Animals/Donkey"),
            answerOptions = new List<string>()
        {
            "cow",
            "parrot",
            "pig",
            "donkey"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Donkey",
            position = new Vector3(-0.9f, 2.4f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName017 = new Question()
        {
            number = 17,
            questionName = "rabbit",
            sprite = Resources.Load<Sprite>("Questions/Animals/Rabbit"),
            answerOptions = new List<string>()
        {
            "rabbit",
            "parrot",
            "pig",
            "donkey"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Rabbit",
            position = new Vector3(-1.55f, 1.4f, 0f),
            scale = new Vector3(0.6f, 0.6f, 1.0f)
        };

        animalName018 = new Question()
        {
            number = 18,
            questionName = "frog",
            sprite = Resources.Load<Sprite>("Questions/Animals/Frog"),
            answerOptions = new List<string>()
        {
            "rabbit",
            "parrot",
            "pig",
            "frog"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Frog",
            position = new Vector3(-1.8f, 0.7f, 0f),
            scale = new Vector3(0.5f, 0.5f, 1.0f)
        };

        animalName019 = new Question()
        {
            number = 19,
            questionName = "tiger",
            sprite = Resources.Load<Sprite>("Questions/Animals/Tiger"),
            answerOptions = new List<string>()
        {
            "tiger",
            "parrot",
            "pig",
            "frog"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Tiger",
            position = new Vector3(-0.6f, 1.4f, 0f),
            scale = new Vector3(1.16f, 1.16f, 1.0f)
        };

        animalName020 = new Question()
        {
            number = 20,
            questionName = "goat",
            sprite = Resources.Load<Sprite>("Questions/Animals/Goat"),
            answerOptions = new List<string>()
        {
            "tiger",
            "parrot",
            "goat",
            "frog"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Goat",
            position = new Vector3(-1.5f, 1.4f, 0f),
            scale = new Vector3(0.814f, 0.814f, 0.814f)
        };

        animalName021 = new Question()
        {
            number = 21,
            questionName = "chicken",
            sprite = Resources.Load<Sprite>("Questions/Animals/Chicken"),
            answerOptions = new List<string>()
        {
            "tiger",
            "parrot",
            "goat",
            "chicken"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Chicken",
            position = new Vector3(-1.8f, 1.3f, 0f),
            scale = new Vector3(0.5f, 0.5f, 1.0f)
        };

        animalName022 = new Question()
        {
            number = 22,
            questionName = "elephant",
            sprite = Resources.Load<Sprite>("Questions/Animals/Elephant"),
            answerOptions = new List<string>()
        {
            "tiger",
            "elephant",
            "goat",
            "chicken"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Elephant",
            position = new Vector3(0f, 2.2f, 0f),
            scale = new Vector3(1.55f, 1.55f, 1.0f)
        };

        animalName023 = new Question()
        {
            number = 23,
            questionName = "lizard",
            sprite = Resources.Load<Sprite>("Questions/Animals/Lizard"),
            answerOptions = new List<string>()
        {
            "tiger",
            "elephant",
            "goat",
            "lizard"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Lizard",
            position = new Vector3(-1.0f, 1f, 0f),
            scale = new Vector3(1.0f, 1.0f, 1.0f)
        };

        animalName024 = new Question()
        {
            number = 24,
            questionName = "bat",
            sprite = Resources.Load<Sprite>("Questions/Animals/Bat"),
            answerOptions = new List<string>()
        {
            "tiger",
            "elephant",
            "bat",
            "lizard"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Bat",
            position = new Vector3(-1.4f, 4f, 0f),
            scale = new Vector3(0.6f, 0.6f, 1.0f)
        };

        animalName025 = new Question()
        {
            number = 25,
            questionName = "eagle",
            sprite = Resources.Load<Sprite>("Questions/Animals/Eagle"),
            answerOptions = new List<string>()
        {
            "tiger",
            "elephant",
            "bat",
            "eagle"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Eagle"
        };

        animalName026 = new Question()
        {
            number = 26,
            questionName = "kangaroo",
            sprite = Resources.Load<Sprite>("Questions/Animals/Kangaroo"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "elephant",
            "bat",
            "eagle"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Kangaroo"
        };

        animalName027 = new Question()
        {
            number = 27,
            questionName = "panda",
            sprite = Resources.Load<Sprite>("Questions/Animals/Panda"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "panda",
            "bat",
            "eagle"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Panda"
        };

        animalName028 = new Question()
        {
            number = 28,
            questionName = "penguin",
            sprite = Resources.Load<Sprite>("Questions/Animals/Penguin"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "panda",
            "bat",
            "penguin"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Penguin"
        };

        animalName029 = new Question()
        {
            number = 29,
            questionName = "sheep",
            sprite = Resources.Load<Sprite>("Questions/Animals/Sheep"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "panda",
            "bat",
            "sheep"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Sheep"
        };

        animalName030 = new Question()
        {
            number = 30,
            questionName = "snake",
            sprite = Resources.Load<Sprite>("Questions/Animals/Snake"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "panda",
            "snake",
            "penguin"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Snake"
        };

        animalName031 = new Question()
        {
            number = 31,
            questionName = "swan",
            sprite = Resources.Load<Sprite>("Questions/Animals/Swan"),
            answerOptions = new List<string>()
        {
            "kangaroo",
            "panda",
            "swan",
            "sheep"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Swan"
        };

        animalName032 = new Question()
        {
            number = 32,
            questionName = "tortoise",
            sprite = Resources.Load<Sprite>("Questions/Animals/Tortoise"),
            answerOptions = new List<string>()
        {
            "tortoise",
            "panda",
            "swan",
            "sheep"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Tortoise",
            position = new Vector3(-1.5f, 0.9f, 0f),
            scale = new Vector3(0.7f, 0.7f, 1.0f)
        };

        animalName033 = new Question()
        {
            number = 33,
            questionName = "shark",
            sprite = Resources.Load<Sprite>("Questions/Animals/Shark"),
            answerOptions = new List<string>()
        {
            "shark",
            "panda",
            "swan",
            "sheep"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Shark",
            position = new Vector3(0f, 1.3f, 0f),
            scale = new Vector3(1.6f, 1.6f, 1.0f)
        };

        animalName034 = new Question()
        {
            number = 34,
            questionName = "dolphin",
            sprite = Resources.Load<Sprite>("Questions/Animals/Dolphin"),
            answerOptions = new List<string>()
        {
            "shark",
            "panda",
            "swan",
            "dolphin"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Dolphin",
            position = new Vector3(-0.9f, 1.4f, 0f),
            scale = new Vector3(1f, 1f, 1.0f)
        };

        animalName035 = new Question()
        {
            number = 35,
            questionName = "mouse",
            sprite = Resources.Load<Sprite>("Questions/Animals/Mouse"),
            answerOptions = new List<string>()
        {
            "shark",
            "panda",
            "mouse",
            "dolphin"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Mouse"
        };

        animalName036 = new Question()
        {
            number = 36,
            questionName = "camel",
            sprite = Resources.Load<Sprite>("Questions/Animals/Camel"),
            answerOptions = new List<string>()
        {
            "shark",
            "panda",
            "mouse",
            "camel"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Camel"
        };

        animalName037 = new Question()
        {
            number = 37,
            questionName = "snail",
            sprite = Resources.Load<Sprite>("Questions/Animals/Snail"),
            answerOptions = new List<string>()
        {
            "shark",
            "snail",
            "mouse",
            "camel"
        },
            tags = new List<string>()
        {
            "animals"
        },
            size = 1,
            answerSound = "Snail"
        };

        LoadQuestionList();
    }

    public static void LoadQuestionList()
    {
        // if (GameControl.animalName001known == false)
        questions.Add(animalName001);

        // if (!GameControl.animalName002known)
        questions.Add(animalName002);

        // if (!GameControl.animalName003known)
        questions.Add(animalName003);

        // if (!GameControl.animalName004known)
        questions.Add(animalName004);

        // if (!GameControl.animalName005known)
        questions.Add(animalName005);

        // if (!GameControl.animalName006known)
        questions.Add(animalName006);

        // if (!GameControl.animalName007known)
        //  questions.Add(animalName007);

        // if (!GameControl.animalName008known)
        //   questions.Add(animalName008);

        // if (!GameControl.animalName009known)
        //   questions.Add(animalName009);

        // if (!GameControl.animalName010known)
        //   questions.Add(animalName010);

        // if (!GameControl.animalName011known)
        //   questions.Add(animalName011);

        // if (!GameControl.animalName012known)
        //  questions.Add(animalName012);

        // if (!GameControl.animalName013known)
        //  questions.Add(animalName013);

        // if (!GameControl.animalName014known)
        questions.Add(animalName014);

        // if (!GameControl.animalName015known)
        questions.Add(animalName015);

        // if (!GameControl.animalName016known)
        questions.Add(animalName016);

        // if (!GameControl.animalName017known)
        questions.Add(animalName017);

        // if (!GameControl.animalName018known)
        questions.Add(animalName018);

        // if (!GameControl.animalName019known)
        questions.Add(animalName019);

        // if (!GameControl.animalName020known)
        questions.Add(animalName020);

        // if (!GameControl.animalName021known)
        questions.Add(animalName021);

        // if (!GameControl.animalName022known)
        questions.Add(animalName022);

        // if (!GameControl.animalName023known)
        questions.Add(animalName023);

        // if (!GameControl.animalName024known)
        questions.Add(animalName024);

        // if (!GameControl.animalName025known)
        //   questions.Add(animalName025);

        // if (!GameControl.animalName026known)
        //  questions.Add(animalName026);

        // if (!GameControl.animalName027known)
        //  questions.Add(animalName027);

        // if (!GameControl.animalName028known)
        //   questions.Add(animalName028);

        // if (!GameControl.animalName029known)
        //  questions.Add(animalName029);

        // if (!GameControl.animalName030known)
        //  questions.Add(animalName030);

        // if (!GameControl.animalName031known)
        //   questions.Add(animalName031);

        // if (!GameControl.animalName032known)
        questions.Add(animalName032);

        // if (!GameControl.animalName033known)
        questions.Add(animalName033);

        // if (!GameControl.animalName034known)
        questions.Add(animalName034);

        // if (!GameControl.animalName035known)
        // questions.Add(animalName035);

        //  questions.Add(animalName036);

        //  questions.Add(animalName037);

        questions = questions.OrderBy(x => System.Guid.NewGuid()).ToList();

        Debug.Log(questions.Count);
    }
}

