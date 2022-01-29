#include "pch.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;


namespace My2AddTwoNumbers
{

	TEST_CLASS(My2AddTwoNumbers) {
public:


	/*
	 * Definition for singly-linked list.
	 */
	struct ListNode {
		int val;
		struct ListNode* next;
	};

	struct ListNode** addTwoNumbersBase(struct ListNode** listPrim, struct ListNode** listSec, int* pCarry, struct ListNode** pItemRes) {
		struct ListNode* itemPrim = *listPrim;
		struct ListNode* itemSec = *listSec;
		int carry = *pCarry;
		while (itemPrim != NULL) {
			int val2;
			if (itemSec != NULL) {
				val2 = itemSec->val;
				itemSec = itemSec->next;
			} else {
				val2 = 0;
			}

			int val = itemPrim->val + val2 + carry;
			if (val >= 10) {
				val = val % 10;
				carry = 1;
			} else {
				carry = 0;
			}

			itemPrim = itemPrim->next;

			*pItemRes = (struct ListNode*)malloc(sizeof(struct ListNode));
			(*pItemRes)->next = NULL;
			(*pItemRes)->val = val;
			pItemRes = &(*pItemRes)->next;
		}
		*listPrim = itemPrim;
		*listSec = itemSec;
		*pCarry = carry;
		return pItemRes;
	}

	struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2) {
		int carry = 0;
		struct ListNode* resList = NULL;
		struct ListNode** pItemRes = &resList;

		pItemRes = addTwoNumbersBase(&l1, &l2, &carry, pItemRes);
		pItemRes = addTwoNumbersBase(&l2, &l1, &carry, pItemRes);
		if (carry != 0) {
			*pItemRes = (struct ListNode*)malloc(sizeof(struct ListNode));
			(*pItemRes)->next = NULL;
			(*pItemRes)->val = carry;
		}
		return resList;
	}

	TEST_METHOD(TestMethod1) {
		//Input: l1 = [2,4,3], l2 = [5,6,4]
		//Output: [7,0,8]
		//Explanation: 342 + 465 = 807.

		struct ListNode list1[3];
		struct ListNode list2[3];

		list1[0].val = 2;
		list1[0].next = &list1[1];
		list1[1].val = 4;
		list1[1].next = &list1[2];
		list1[2].val = 3;
		list1[2].next = NULL;

		list2[0].val = 5;
		list2[0].next = &list2[1];
		list2[1].val = 6;
		list2[1].next = &list2[2];
		list2[2].val = 4;
		list2[2].next = NULL;

		struct ListNode* res = addTwoNumbers((struct ListNode*)&list1, (struct ListNode*)&list2);

		Assert::IsNotNull(res);
		Assert::AreEqual(res->val, 7);
		Assert::IsNotNull(res->next);
		Assert::AreEqual(res->next->val, 0);
		Assert::IsNotNull(res->next->next);
		Assert::AreEqual(res->next->next->val, 8);
		Assert::IsNull(res->next->next->next);
	}

	TEST_METHOD(TestMethod2) {
		//Input: l1 = [0], l2 = [0]
		//Output: [0]

		struct ListNode list1[1];
		struct ListNode list2[1];

		list1[0].val = 0;
		list1[0].next = NULL;

		list2[0].val = 0;
		list2[0].next = NULL;

		struct ListNode* res = addTwoNumbers((struct ListNode*)&list1, (struct ListNode*)&list2);

		Assert::IsNotNull(res);
		Assert::AreEqual(res->val, 0);
		Assert::IsNull(res->next);
	}

	TEST_METHOD(TestMethod3) {
		//Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
		//Output: [8,9,9,9,0,0,0,1]

		struct ListNode list1[7];
		struct ListNode list2[4];

		list1[0].val = 9;
		list1[0].next = &list1[1];
		list1[1].val = 9;
		list1[1].next = &list1[2];
		list1[2].val = 9;
		list1[2].next = &list1[3];
		list1[3].val = 9;
		list1[3].next = &list1[4];
		list1[4].val = 9;
		list1[4].next = &list1[5];
		list1[5].val = 9;
		list1[5].next = &list1[6];
		list1[6].val = 9;
		list1[6].next = NULL;

		list2[0].val = 9;
		list2[0].next = &list2[1];
		list2[1].val = 9;
		list2[1].next = &list2[2];
		list2[2].val = 9;
		list2[2].next = &list2[3];
		list2[3].val = 9;
		list2[3].next = NULL;

		struct ListNode* res = addTwoNumbers((struct ListNode*)&list1, (struct ListNode*)&list2);

		Assert::IsNotNull(res);
		Assert::AreEqual(res->val, 8);
		Assert::IsNotNull(res->next);
		Assert::AreEqual(res->next->val, 9);
		Assert::IsNotNull(res->next->next);
		Assert::AreEqual(res->next->next->val, 9);
		Assert::IsNotNull(res->next->next->next);
		Assert::AreEqual(res->next->next->next->val, 9);

		Assert::IsNotNull(res->next->next->next->next);
		Assert::AreEqual(res->next->next->next->next->val, 0);
		Assert::IsNotNull(res->next->next->next->next->next);
		Assert::AreEqual(res->next->next->next->next->next->val, 0);
		Assert::IsNotNull(res->next->next->next->next->next->next);
		Assert::AreEqual(res->next->next->next->next->next->next->val, 0);

		Assert::IsNotNull(res->next->next->next->next->next->next->next);
		Assert::AreEqual(res->next->next->next->next->next->next->next->val, 1);

		Assert::IsNull(res->next->next->next->next->next->next->next->next);
	}



	};
}
