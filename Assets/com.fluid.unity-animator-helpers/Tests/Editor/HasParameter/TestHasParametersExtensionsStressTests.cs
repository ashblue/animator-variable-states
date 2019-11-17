﻿using Adnc.AnimatorHelpers.Editors.Testing.Utilities;
using Adnc.AnimatorHelpers.HasParameters;
using NUnit.Framework;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.Testing.HasParameters {
    [TestFixture(Category = "HasParameter")]
    public class TestHasParametersExtensionsStressTests {
        private AnimatorStub _stub;
        private AnimatorHelperRuntime _runtime;

        [SetUp]
        public void Setup () {
            _runtime = new GameObject("AnimatorRuntime").AddComponent<AnimatorHelperRuntime>();
            _stub = new AnimatorStub();
        }

        [TearDown]
        public void Teardown () {
            Object.DestroyImmediate(_stub.Animator.gameObject);
            _stub = null;

            Object.DestroyImmediate(_runtime.gameObject);
            AnimatorHelperRuntime.ClearSingleton();
            _runtime = null;
        }

        [Test]
        public void CallWithSingleParameter () {
            _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                name = "bool",
                type = AnimatorControllerParameterType.Bool
            });

            _stub.InjectCtrl();

            _stub.Animator.HasBool("bool");
        }

        [Test]
        public void CallWithHundredParameters () {
            for (var i = 0; i < 100; i++) {
                _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                    name = "bool" + i,
                    type = AnimatorControllerParameterType.Bool
                });
            }

            _stub.InjectCtrl();

            _stub.Animator.HasBool("bool");
        }

        [Test]
        public void CallWithThosandParameters () {
            for (var i = 0; i < 1000; i++) {
                _stub.AnimatorCtrl.AddParameter(new AnimatorControllerParameter {
                    name = "bool" + i,
                    type = AnimatorControllerParameterType.Bool
                });
            }

            _stub.InjectCtrl();

            _stub.Animator.HasBool("bool");
        }
    }
}
